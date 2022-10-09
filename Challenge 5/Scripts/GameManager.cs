using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace challenge5
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject titleScreen;

        [SerializeField] private TextMeshProUGUI scoreText;
        private int score;

        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private Button restartButton;

        [SerializeField] private List<GameObject> targetPrefabs;
        private float spawnRate = 1.5f;

        public bool isGameActive;

        [SerializeField] private TextMeshProUGUI timeText;
        private int timer = 60;

        private float spaceBetweenSquares = 2.5f;
        private float minValueX = -3.75f; //  x value of the center of the left-most square
        private float minValueY = -3.75f; //  y value of the center of the bottom-most square



        // Assign settings when starting the game
        public void StartGame(int difficulty)
        {
            spawnRate /= difficulty;

            isGameActive = true;
            titleScreen.SetActive(false);

            StartCoroutine(SpawnTarget());

            UpdateScore(0);

            StartCoroutine(UpdateTime());
        }


        // Spawn a random target in a random position
        private IEnumerator SpawnTarget()
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, targetPrefabs.Count);

                if (isGameActive)
                    Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
        }


        // Generate a random spawn position
        private Vector3 RandomSpawnPosition()
        {
            float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
            float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

            Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
            return spawnPosition;
        }


        // Generates random square index, which determines which square the target will appear in
        private int RandomSquareIndex()
        {
            return Random.Range(0, 4);
        }


        // Update score with value from target clicked
        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = $"Score: {score}";
        }


        // Counts down from 60 seconds
        private IEnumerator UpdateTime()
        {
            for (int i = timer; i >= 0; i--)
            {
                if (isGameActive)
                {
                    timeText.text = $"Time: {i}";
                    yield return new WaitForSeconds(1);
                }
            }

            GameOver();
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