using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatsData
{
    public class Cat : MonoBehaviour
    {
        public CatData Data;
        [SerializeField] private GameEvent CatPickUpFood;
        public static float _foodInCells { get; set; }

        public void CheckTag()
        {
            CatPickUpFood.Raise();
        }
    }
}

