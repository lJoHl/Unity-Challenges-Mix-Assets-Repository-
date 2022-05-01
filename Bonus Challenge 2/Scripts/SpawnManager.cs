using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;

    public float spawnRangeX = 20;
    public float spawnPosZ = 20;

    public float spawnDelay = 2;
    public float spawnInterval = 1.5f;


    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 5, 5);
    }

    // Update is called once per frame
    private void Update()
    {

    }


    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animals.Length - 1);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animals[animalIndex], spawnPos, animals[0].transform.rotation);
    }
}
