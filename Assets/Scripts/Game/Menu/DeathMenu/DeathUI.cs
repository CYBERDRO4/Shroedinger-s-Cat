using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameEvent EndOfTheGame;
    [SerializeField]private Text gameScore;
    public void ActivateDeathUI()
    {
        deathUI.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
        EndOfTheGame.Raise();
    }
    public void ShowGameScore()
    {
        if (Bank.FeedBank._gameScore.ToString() != null)
            gameScore.text = Bank.FeedBank._gameScore.ToString();
        else
            gameScore.text = "0";
    }
}
