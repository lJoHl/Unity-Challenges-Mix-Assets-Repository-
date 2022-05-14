using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BonusChallenge5
{
    public class DifficultyButton : MonoBehaviour
    {
        private Button button;

        private GameManager gameManagerScript;

        public int difficulty;


        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SetDifficulty);

            gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        }


        private void Update()
        {

        }


        void SetDifficulty()
        {
            Debug.Log($"{button.gameObject.name} was clicked");

            gameManagerScript.StartGame(difficulty);
        }
    }
}