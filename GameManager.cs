using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MenuManager
{
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private int lives;

    //[SerializeField] private TextMeshProUGUI rankedScorePosition;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

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


    protected override void EscAction()
    {
        
    }
}
