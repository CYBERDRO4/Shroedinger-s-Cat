using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatsData
{
    [CreateAssetMenu(fileName = "NewCat", menuName = "Data/Cat", order = 51)]
    public class CatData : ScriptableObject
    {
        private string Name;

        public float speedMultiplicator;


        public float hungerTimeMultiply;
        public int maxCells;


        public Sprite fullCell;
        public Sprite emptyCell;

    }

}

