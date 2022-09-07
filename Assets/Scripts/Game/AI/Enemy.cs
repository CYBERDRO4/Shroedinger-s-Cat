using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Utils;
using Game.Rooms;

namespace Game.AI
{
    public abstract class Enemy : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] protected EnemyData _data;

        [Header("Subscripts")]
        [SerializeField] protected VisualBehaviour _visual;
        [SerializeField] protected EnemyTimers _timers;

        protected Transform _player;

        public bool eats { get; set; } = false;

        public event Action onFoodReached;

        private Feed _targetFeed = null;

        private Coroutine walkingCoroutine = null;

        public delegate void OnMoved();

        public EnemyData enemyData { get { return _data; } }

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            onFoodReached += OnFoodReached;
            _timers.OnFoodSearchingTimeOver += OnFoodSearchingOver;
            _timers.StartFoodSearchingTimer();
        }

        private void Update()
        {
            // Тут должен был быть код отпугивания птицы, но я подумал, что и так норм
        }

        #region abstract methods
        /**<summary>Обработчик события получения удара</summary>*/
        public abstract void GetHit();
        #endregion

        /**<summary>Плавно перемеситься к <paramref name="target"/></summary>*/
        public void MoveTo(Vector2 target, OnMoved onMoved)
        {
            Debug.Log("Move to");
            eats = false;
            if (walkingCoroutine != null)
                StopCoroutine(walkingCoroutine);
            _visual.PlayFlyAnimation();
            walkingCoroutine = StartCoroutine(MoveToCoroutine(target, onMoved));
        }
        /**<summary>Отнять от источника корма единицы корма</summary>*/
        public void Eat()
        {
            if (_targetFeed)
            {
                _targetFeed.SubtractFood(_data.eatVolume);
            }
            else
            {
                _timers.StopEatingTimer();
            }
        }

        /**<summary>Проверка на наличие корма в комнате</summary>*/
        public bool FindFood(out Feed target)
        {

            var food = Singletone<Room>.instance.food;
            if (food.Count > 0)
            {
                Feed f = null;
                float distance = float.MaxValue;
                for (int i = 0; i < food.Count; i++)
                {
                    var d = Vector2.Distance(transform.position, food[i].transform.position);
                    if (d < distance)
                    {
                        distance = d;
                        f = food[i];
                    }
                }
                target = f;
                target.OnFoodEnd += OnFoodEnd;
                return true;
            }

            target = null;
            return false;
        }

        /**<summary>Обработчик события истощения источника корма</summary>*/
        private void OnFoodEnd()
        {
            Debug.Log("On food end");
            _timers.StopEatingTimer();
            _timers.StartFoodSearchingTimer();
            if (walkingCoroutine != null)
            {
                StopCoroutine(walkingCoroutine);
                WalkAround(24);
            }
        }

        /**<summary>Обработчик события окончания поиска корма</summary>*/
        private void OnFoodSearchingOver()
        {
            if (FindFood(out _targetFeed))
            {
                MoveTo(_targetFeed.transform.position, OnFoodReached);
            }
        }

        /**<summary>Начать летать вокруг в радиусе <paramref name="r"/></summary>*/
        public void WalkAround(float r)
        {
            Debug.Log("Walk around");
            eats = false;
            if (walkingCoroutine != null)
                StopCoroutine(walkingCoroutine);
            walkingCoroutine = StartCoroutine(WalkAroundCoroutine(r));
        }

        /**<summary>Отпугнуться</summary>*/
        public void GetScared() {
            var escapeDir = new Vector2(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1));
            var escapeRange = UnityEngine.Random.Range(0.4f, 5f);
            var espacePos = escapeDir * escapeRange;
            eats = false;
            MoveTo(espacePos, ()=> {
                WalkAround(18);
            });
        }

        /**<summary>Обработчик события поражения объекта врага</summary>*/
        public void OnDefeated() {
            Destroy(gameObject);
        }

        #region coroutines
        private IEnumerator MoveToCoroutine(Vector2 targetPos, OnMoved onMoved)
        {
            Vector2 startPos = transform.position;
            float step = (_data.moveSpeed / (targetPos - startPos).magnitude) * Time.fixedDeltaTime;
            float t = 0;

            while (t < 1)
            {
                t += step;
                transform.position = Vector2.Lerp(startPos, targetPos, t);
                yield return new WaitForFixedUpdate();
            }

            transform.position = targetPos;
            onMoved?.Invoke();
        }

        private IEnumerator WalkAroundCoroutine(float r)
        {

            float x, y;
            float t = 0;
            _visual.PlayFlyAnimation();
            while (true)
            {
                t += Time.fixedDeltaTime * _data.moveSpeed;
                transform.position += new Vector3(
                    Mathf.Cos(t) + UnityEngine.Random.Range(-0.25f, 0.25f),
                    Mathf.Sin(t) + UnityEngine.Random.Range(-0.25f, 0.25f),
                    0) / r;
                yield return new WaitForFixedUpdate();
            }
        }
        #endregion

        /**<summary>Обработчик события достижения источника корма</summary>*/
        private void OnFoodReached()
        {
            Debug.Log("Food reached");
            eats = true;
            _targetFeed.isBirdOnFood = true;
            _visual.PlayEatingAnimation();
            _timers.StartEatingTimer();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Bowl")
                GetHit();
        }
    }
}