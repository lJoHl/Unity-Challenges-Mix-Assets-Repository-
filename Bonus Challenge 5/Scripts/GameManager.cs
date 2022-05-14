using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BonusChallenge5
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> targets;

        private float spawnRate = 1.0f;

        public GameObject titleScreen;

        public TextMeshProUGUI scoreText;
        private int score = 0;

        public TextMeshProUGUI gameOverText;
        public Button restartButton;

        public bool isGameActive;


        private void Start()
        {
            
        }

        private void Update()
        {

        }


        IEnumerator SpawnTarget()
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);

                int index = Random.Range(0, targets.Count);

                Instantiate(targets[index]);
            }
        }


        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;    
            scoreText.text = $"Score: {score}";
        }


        public void GameOver()
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }


        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        public void StartGame(int difficulty)
        {
            isGameActive = true;

            spawnRate /= difficulty;

            StartCoroutine(SpawnTarget());

            UpdateScore(0);

            titleScreen.SetActive(false);
        }
    }
}