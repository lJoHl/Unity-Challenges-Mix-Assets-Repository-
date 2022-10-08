using UnityEngine;

namespace bonusChallenge3
{
    public class SpawnManager : MonoBehaviour
    {
        private PlayerController playerControllerScript;

        [SerializeField] private GameObject[] obstacles;

        private Vector3 spawnObstaclesPos = new Vector3(25, 0, 0);

        private float startDelay = 3; 
        private float repeatRate = 2;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

            InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        }


        private void SpawnObstacle()
        {
            int obstacleIndex = Random.Range(0, obstacles.Length);


            if (!playerControllerScript.gameOver)
                Instantiate(obstacles[obstacleIndex], spawnObstaclesPos, obstacles[obstacleIndex].transform.rotation);
        }
    }
}