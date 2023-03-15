using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MenuManager  //Remember to write comments
{
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private int lives;

    //[SerializeField] private TextMeshProUGUI rankedScorePosition;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    [SerializeField] private GameObject pauseMenu;

    private void Lose1Live()
    {
        lives--;
        UpdateCounterText(lives, livesText.text);
    }

    private void UpdateScore(int points)
    {
        score += points;
        UpdateCounterText(score, scoreText.text);
    }

    private void UpdateCounterText(int counter, string counterText)
    {
        counterText = counter.ToString();
    }


    public override void EscAction()
    {
        try
        {
            GameObject menu = GameObject.Find($"{pauseMenu.name}(Clone)");

            if (menu.activeInHierarchy)
            {
                CloseMenu(menu);
                Time.timeScale = 1;
            }
        }
        catch
        {
            OpenMenu(pauseMenu);
            Time.timeScale = 0;
        }
    }
}
