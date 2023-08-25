using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSelectorManager : MenuManager  //Remember to write comments
{
    private int[] gameIds = new int[9];
    private int currentGameId;

    [SerializeField] private string[] gameTitles;
    [SerializeField] private TextMeshProUGUI gameTitle;   


    public void ChangeGameId(int gameId)
    {
        currentGameId = gameId;

        //Borrar?
        UpdateGameTitle();
    }


    private void UpdateGameTitle()
    {
        gameTitle.text = gameTitles[currentGameId];
    }


    public void Play()
    {
        ChangeScene(currentGameId.ToString());
    }
}
