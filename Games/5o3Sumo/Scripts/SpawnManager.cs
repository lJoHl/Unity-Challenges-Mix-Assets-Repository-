using UnityEngine;

namespace bonusChallenge4
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemyPrefabs;

        [SerializeField] private GameObject bossPrefab;
        [SerializeField] private GameObject[] miniEnemyPrefabs;
        [SerializeField] private int bossRound;

        [SerializeField] private GameObject[] powerupPrefabs;

        private float spawnRange = 9.0f;

        private int enemyCount;
        private int waveNumber = 0;


        // Spawns enemies and power-ups, increasing their number each round
        private void Update()
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0)
            {
                waveNumber++;

                if (waveNumber % bossRound == 0)
                    SpawnBossWave(waveNumber);
                else
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


        private void SpawnBossWave(int currentRound)
        {
            int miniEnemysToSpawn;

            if (bossRound != 0)
                miniEnemysToSpawn = currentRound / bossRound;
            else
                miniEnemysToSpawn = 1;

            var boss = Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
            boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
        }


        public void SpawnMiniEnemy(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
                Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(), miniEnemyPrefabs[randomMini].transform.rotation);
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