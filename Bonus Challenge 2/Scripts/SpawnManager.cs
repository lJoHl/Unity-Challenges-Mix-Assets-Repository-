using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;

    public float spawnLimitRangeX = 20;
    private float spawnTopLimitZ = 16;
    private float spawnLowerLimitZ = -1;

    public float spawnPosZ = 20;
    public float spawnPosX = 30;

    public float spawnDelay = 2;
    public float spawnInterval = 1.5f;


    // Start is called before the first frame update
    private void Start()
    {
        Invoke("SpawnTopRandomAnimal", 5);
        Invoke("SpawnLeftRandomAnimal", 4);
        Invoke("SpawnRightRandomAnimal", 6);
    }


    // Update is called once per frame
    private void Update()
    {

    }


    private void SpawnTopRandomAnimal()
    {
        int animalIndex = Random.Range(0, animals.Length);

        Vector3 spawnTopPos = new Vector3(Random.Range(-spawnLimitRangeX, spawnLimitRangeX), 0, spawnPosZ);

        Instantiate(animals[animalIndex], spawnTopPos, animals[0].transform.rotation);

        Invoke("SpawnTopRandomAnimal", Random.Range(1, 5));
    }


    private void SpawnLeftRandomAnimal()
    {
        int animalIndex = Random.Range(0, animals.Length);

        Vector3 spawnLeftPos = new Vector3(-spawnPosX, 0, Random.Range(spawnLowerLimitZ, spawnTopLimitZ));

        Instantiate(animals[animalIndex], spawnLeftPos, animals[1].transform.rotation);

        Invoke("SpawnLeftRandomAnimal", Random.Range(1, 4));
    }


    private void SpawnRightRandomAnimal()
    {
        int animalIndex = Random.Range(0, animals.Length);

        Vector3 spawnRightPos = new Vector3(spawnPosX, 0, Random.Range(spawnLowerLimitZ, spawnTopLimitZ));

        Instantiate(animals[animalIndex], spawnRightPos, animals[2].transform.rotation);

        Invoke("SpawnRightRandomAnimal", Random.Range(1, 6));
    }
}
