using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons: MonoBehaviour
{
    public void StartGame()
    {
        StartScore();
        SceneManager.LoadScene("LearningScene");
    }
    public void ExitGame()
    {
        Debug.Log("выход из приложения");
        Application.Quit();
    }

    public void DeleteScore()
    {
        Bank.FeedBank._maxScore = 0;
        PlayerPrefs.SetInt("MaxScore", Bank.FeedBank._maxScore);
    }
    private void StartScore()
    {
        Bank.FeedBank._maxScore = PlayerPrefs.GetInt("MaxScore");
        Bank.FeedBank._feedCount = 0;
        Bank.FeedBank._gameScore = 0;
    }
}
