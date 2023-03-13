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
        [SerializeField] private List<GameObject> targets;
        private float spawnRate = 1.0f;

        [SerializeField] private GameObject titleScreen;

        [SerializeField] private TextMeshProUGUI scoreText;
        private int score = 0;

        [SerializeField] private TextMeshProUGUI livesText;
        private int lives;

        [SerializeField] private GameObject pauseScreen;
        private bool paused;

        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private Button restartButton;

        public bool isGameActive;


        public void StartGame(int difficulty)
        {
            isGameActive = true;
            titleScreen.SetActive(false);

            spawnRate /= difficulty;
            StartCoroutine(SpawnTarget());

            UpdateScore(0);
            UpdateLives(3);
        }


        private IEnumerator SpawnTarget()
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);

                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }


        public void UpdateLives(int livesToChange)
        {
            lives += livesToChange;
            livesText.text = "Lives: " + lives;

            if (lives <= 0)
                GameOver();
        }


        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = $"Score: {score}";
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                ChangePaused();
        }


        private void ChangePaused()
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
    }
}