using UnityEngine;

namespace challenge4
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        [SerializeField] private GameObject powerupPrefab;

        private GameObject player;

        private Enemy enemy;

        private float spawnRangeX = 10;
        private float spawnZMin = 15; // set min spawn Z
        private float spawnZMax = 25; // set max spawn Z

        private int enemyCount;
        private int waveCount = 1;


        private void Start()
        {
            player = GameObject.Find("Player");

            enemy = enemyPrefab.GetComponent<Enemy>();
            enemy.speed = 250;
        }


        private void Update()
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount == 0)
            {
                SpawnEnemyWave(waveCount);
                enemy.speed += 50;
            }
        }


        // Generate random spawn position for powerups and enemy balls
        private Vector3 GenerateSpawnPosition()
        {
            float xPos = Random.Range(-spawnRangeX, spawnRangeX);
            float zPos = Random.Range(spawnZMin, spawnZMax);
            return new Vector3(xPos, 0, zPos);
        }


        private void SpawnEnemyWave(int enemiesToSpawn)
        {
            Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

            // If no powerups remain, spawn a powerup
            if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
                Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);

            // Spawn number of enemy balls based on wave number
            for (int i = 0; i < enemiesToSpawn; i++)
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

            waveCount++;
            ResetPlayerPosition(); // put player back at start

        }


        // Move player back to position in front of own goal
        private void ResetPlayerPosition()
        {
            player.transform.position = new Vector3(0, 1, -7);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}