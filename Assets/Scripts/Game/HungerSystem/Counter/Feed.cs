using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Exeptions;
using CatsData;
using Game.Utils;
using Game.Rooms;

public class Feed : MonoBehaviour
{
    [SerializeField] private GameEvent PickUpFeed;
    public event Action OnFoodEnd;

    [SerializeField] [Range(1, 2048)] private float _foodCount = 512;
    private bool _isBirdOnFood = false;
    public bool isBirdOnFood { get; set; }
    public float foodCount { get { return _foodCount; } }

    private bool foodistouched;

    private void PickUp()
    {
        Bank.FeedBank._feedCount++;
        Destroy(gameObject);
    }

    public void SubtractFood(float value) {
        if (value > 0)
        {
            _foodCount -= value;
            if (_foodCount <= 0) {
                OnFoodEnd?.Invoke();
                Destroy(gameObject);
            }
        }
        else {
            throw new SetupExeption("Food count for subtract must be positive!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bowl" && _isBirdOnFood == false)
        {
            foodistouched = true;
            PickUpFeed.Raise();
            OnFoodEnd?.Invoke();
        }
    }
    public void PickedUp()
    {
        if(foodistouched)
            Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Singletone<Room>.instance.food.Remove(this);
    }
}
