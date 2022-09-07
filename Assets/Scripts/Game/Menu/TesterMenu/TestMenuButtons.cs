using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestMenuButtons : MonoBehaviour
{
    private bool menu_is_active = false;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameEvent TheEndOfGame;
    [SerializeField] private Text gameScore;
    public void ShowHideMenu()
    {
        menu_is_active = !menu_is_active;
        menu.SetActive(menu_is_active);
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void Update()
    {
        if (Bank.FeedBank._gameScore.ToString() != null)
            gameScore.text = Bank.FeedBank._gameScore.ToString();
        else
            gameScore.text = "0";
    }
}
