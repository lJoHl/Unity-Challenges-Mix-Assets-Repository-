using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bonusChallenge4
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] enemyPrefabs;
        public GameObject[] powerupPrefabs;

        private float spawnRange = 9.0f;

        public int enemyCount;
        public int waveNumber = 1;


        private void Start()
        {
            SpawnEnemyWave(waveNumber); // metodo innecesario

            int randomPowerup = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
        }


        private void Update()
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);

                int randomPowerup = Random.Range(0, powerupPrefabs.Length);
                Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
            }
        }


        private void SpawnEnemyWave(int enemysToSpawn)
        {
            for (int i = 0; i < enemysToSpawn; i++)
            {
                int randomEnemy = Random.Range(0, enemyPrefabs.Length);

                Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
            }
        } 


        private Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-spawnRange, spawnRange);

            Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

            return randomPos;
        }
    }
}