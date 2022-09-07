using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HungerSystem
{
    public class Hunger : MonoBehaviour
    {
        [SerializeField] private GameEvent AddHungerDone;
        [SerializeField] private int FoodOnStart;
        [SerializeField] private GameEvent FeedIsOver;

        private void Start()
        {
            CatsData.Cat._foodInCells = FoodOnStart;
        }

        private void FixedUpdate()
        {
            if (CatsData.Cat._foodInCells <= 0.0)
                FeedIsOver.Raise();
            else
                HungerActive();
        }
        private void HungerActive()
        {
            if (CatsData.Cat._foodInCells > 0)
                CatsData.Cat._foodInCells -= Time.fixedDeltaTime * this.GetComponent<CatsData.Cat>().Data.hungerTimeMultiply;
        }

        public void AddFoodInCells()
        {
            while (Convert.ToInt32(CatsData.Cat._foodInCells) < this.GetComponent<CatsData.Cat>().Data.maxCells)
            {
                if (this.GetComponent<CatsData.Cat>().Data.maxCells - 1 < CatsData.Cat._foodInCells)
                    break;
                else
                {
                    if (Bank.FeedBank._feedCount > 0)
                    {
                        CatsData.Cat._foodInCells++;
                        Bank.FeedBank._feedCount--;
                    }
                    else
                        break;
                }
            }
            AddHungerDone.Raise();
        }
    }
}


