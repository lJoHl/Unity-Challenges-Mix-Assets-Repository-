using UnityEngine;

namespace Challenge3
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] objectPrefabs;
        private float spawnDelay = 2;
        private float spawnInterval = 1.5f;

        private PlayerController playerControllerScript;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

            InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        }


        // Spawn obstacles
        private void SpawnObjects()
        {
            // set random spawn location and random object index
            Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
            int index = Random.Range(0, objectPrefabs.Length);

            // if game is still active, spawn new object
            if (!playerControllerScript.gameOver)
                Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}