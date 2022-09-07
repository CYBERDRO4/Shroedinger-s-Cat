using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public void AddGameScore()
    {
        Bank.FeedBank._gameScore += Bank.FeedBank._remainder;
        Bank.FeedBank._remainder = 0;
    }

    public void UpdateScore()
    {
        if (Bank.FeedBank._gameScore > PlayerPrefs.GetInt("MaxScore"))
            Bank.FeedBank._maxScore = Bank.FeedBank._gameScore;
        PlayerPrefs.SetInt("MaxScore", Bank.FeedBank._maxScore);
        Bank.FeedBank._gameScore = 0;
    }
}
