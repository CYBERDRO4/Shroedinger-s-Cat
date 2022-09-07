using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bank
{
    public class CollectUI : MonoBehaviour
    {
        private Text counter;
        void Start()
        {
            counter = GetComponent<Text>();
        }

        void Update()
        {
            ShowCount();
        }
        void ShowCount()
        {
            counter.text = (FeedBank._feedCount + FeedBank._remainder).ToString();
        }
    }
}
