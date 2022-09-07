using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualScore : MonoBehaviour
{
    private Text score;

    private void Start()
    {
        score = GetComponent<Text>();
    }

    private void Update()
    {
        ShowScore();
    }

    public void ShowScore()
    {
        score.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }
}
