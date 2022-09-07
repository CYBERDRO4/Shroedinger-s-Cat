using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStarter : MonoBehaviour
{
    void Start()
    {
        Bank.FeedBank._maxScore = PlayerPrefs.GetInt("MaxScore");
    }
}
