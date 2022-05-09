using UnityEngine;

namespace BonusChallenge2
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] animals;

        private float spawnLimitRangeX = 20;
        private float spawnTopLimitZ = 16;
        private float spawnLowerLimitZ = -1;

        private float spawnPosZ = 20;
        private float spawnPosX = 20;


        private void Start()
        {
            Invoke("SpawnTopRandomAnimal", 5);
            Invoke("SpawnLeftRandomAnimal", 4);
            Invoke("SpawnRightRandomAnimal", 6);
        }


        // Summon animals from the top of the screen
        private void SpawnTopRandomAnimal()
        {
            int animalIndex = Random.Range(0, animals.Length);
            Vector3 spawnTopPos = new Vector3(Random.Range(-spawnLimitRangeX, spawnLimitRangeX), 0, spawnPosZ);

            Instantiate(animals[animalIndex], spawnTopPos, animals[0].transform.rotation);

            Invoke("SpawnTopRandomAnimal", Random.Range(1, 5));
        }


        // Summon animals from the left side of the screen
        private void SpawnLeftRandomAnimal()
        {
            int animalIndex = Random.Range(0, animals.Length);
            Vector3 spawnLeftPos = new Vector3(-spawnPosX, 0, Random.Range(spawnLowerLimitZ, spawnTopLimitZ));

            Instantiate(animals[animalIndex], spawnLeftPos, animals[1].transform.rotation);

            Invoke("SpawnLeftRandomAnimal", Random.Range(1, 4));
        }


        // Summon animals from the right side of the screen
        private void SpawnRightRandomAnimal()
        {
            int animalIndex = Random.Range(0, animals.Length);
            Vector3 spawnRightPos = new Vector3(spawnPosX, 0, Random.Range(spawnLowerLimitZ, spawnTopLimitZ));

            Instantiate(animals[animalIndex], spawnRightPos, animals[2].transform.rotation);

            Invoke("SpawnRightRandomAnimal", Random.Range(1, 6));
        }
    }
}