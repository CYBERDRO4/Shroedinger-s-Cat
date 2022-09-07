using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.AI
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyTimers : MonoBehaviour
    {
        private Enemy _mainScript;
        private EnemyData _data;

        public event Action OnFoodSearchingTimeOver;
        public bool isInFoodSearching = false;
        private Coroutine _foodSearchingTimer;

        private Coroutine _eatingTimer;
        public bool isEating = false;

        #region unity methods
        private void Start()
        {
            _mainScript = GetComponent<Enemy>();
            _data = _mainScript.enemyData;
        }
        #endregion
        #region control methods
        public void StartFoodSearchingTimer()
        {
            if (isInFoodSearching == false)
            {
                Debug.Log("Start searching timer");
                isInFoodSearching = true;
                _mainScript.WalkAround(24); // чем больше - тем меньше радиус (хотя задумывалось наоброт)
                _foodSearchingTimer = StartCoroutine(FoodSearchingTimerCoroutine(_data.foodSearchTime));
            }
        }

        public void StartEatingTimer()
        {
            if (!isEating)
            {
                isEating = true;
                _eatingTimer = StartCoroutine(EatingTimerCoroutine(_data.eatSpeed));
            }
        }

        public void StopFoodSearchingTimer()
        {
            if (_foodSearchingTimer != null)
            {
                isInFoodSearching = false;
                StopCoroutine(_foodSearchingTimer);
            }
        }

        public void StopEatingTimer()
        {
            if (_eatingTimer != null)
            {
                isEating = false;
                StopCoroutine(_eatingTimer);
            }
        }
        #endregion
        #region coroutines
        private IEnumerator FoodSearchingTimerCoroutine(float t)
        {
            Debug.Log("Food searching start...");
            yield return new WaitForSeconds(t);
            OnFoodSearchingTimeOver?.Invoke();
            isInFoodSearching = false;
            Debug.Log("Food searching end.");
        }
        private IEnumerator EatingTimerCoroutine(float t)
        {
            while (isEating)
            {
                yield return new WaitForSeconds(t);
                _mainScript.Eat();
            }
        }
        #endregion
    }
}