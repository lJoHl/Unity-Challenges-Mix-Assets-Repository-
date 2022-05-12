using UnityEngine;

namespace bonusChallenge3
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] obstacles;

        private Vector3 spawnPos = new Vector3(25, 0, 0);

        private float startDelay = 2;  // 5
        private float repeatRate = 2;  // 3

        private PlayerController playerControllerScript; // PCInMV


        private void Start()
        {
            InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }


        private void Update()
        {

        }


        private void SpawnObstacle()
        {
            int obstacleIndex = Random.Range(0, obstacles.Length);

            if (playerControllerScript.gameOver == false) // cambiar por !playerControllerScript.gameOver
                Instantiate(obstacles[obstacleIndex], spawnPos, obstacles[obstacleIndex].transform.rotation);
        }
    }
}