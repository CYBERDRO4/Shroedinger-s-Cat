using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    [CreateAssetMenu(menuName = "Data/Enemy", fileName = "New enemy")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField][Range(0, 25)] private float _eatSpeed; // Раз во сколько секунд жрет
        [SerializeField][Range(1, 128)] private float _eatVolume; // Сколько жрет
        [SerializeField][Range(0.25f, 25)] private float _moveSpeed; // Скорость движения
        [SerializeField][Range(3, 100)] private float _foodSearchTime; // Сколько тупит в поисках пищи
        [SerializeField] [Range(0, 1000)] private float _angularSpeed;

        public float eatSpeed { get { return _eatSpeed; } } 
        public float eatVolume { get { return _eatVolume; } }
        public float moveSpeed { get { return _moveSpeed; } }
        public float foodSearchTime { get { return _foodSearchTime; } }
        public float angularSpeed { get { return _angularSpeed; } }
    }
}
