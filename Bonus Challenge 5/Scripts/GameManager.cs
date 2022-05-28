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

        public TextMeshProUGUI livesText;
        private int lives;

        public GameObject pauseScreen;
        private bool paused;



        private void Start()
        {
            
        }

        private void Update()
        {
            //Check if the user has pressed the P key
            if (Input.GetKeyDown(KeyCode.P))
            {
                ChangePaused();
            }
        }


        public void UpdateLives(int livesToChange)
        {
            lives += livesToChange;
            livesText.text = "Lives: " + lives;
            if (lives <= 0)
            {
                GameOver();
            }
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

            UpdateLives(3);
        }


        void ChangePaused()
        {
            if (!paused)
            {
                paused = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
        }

    }
}