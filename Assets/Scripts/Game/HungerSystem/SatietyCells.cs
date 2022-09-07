using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using CatsData;

namespace HungerSystem
{
    public class SatietyCells : MonoBehaviour
    {
        [SerializeField] GameObject cat;


        [SerializeField] private Image[] lives;

        private void CellCheck()
        {
            if (Cat._foodInCells > cat.GetComponent<Cat>().Data.maxCells)
                Cat._foodInCells = cat.GetComponent<Cat>().Data.maxCells;
            if (cat.GetComponent<Cat>().Data.maxCells > lives.Length)
                cat.GetComponent<Cat>().Data.maxCells = lives.Length;
        }

        void Update()
        {
            CellCheck();
            MainCellsUpdate();
        }

        private void MainCellsUpdate()
        {
            for (int i = 0; i < lives.Length; i++)
            {
                lives[i].sprite = i < Cat._foodInCells ? cat.GetComponent<Cat>().Data.fullCell : cat.GetComponent<Cat>().Data.emptyCell;
                lives[i].enabled = i < cat.GetComponent<Cat>().Data.maxCells ? true : false;
            }
        }
    }
}


