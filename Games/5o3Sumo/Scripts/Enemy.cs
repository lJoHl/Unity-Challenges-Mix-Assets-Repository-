using UnityEngine;

namespace bonusChallenge4
{
    public class Enemy : MonoBehaviour
    {
        private Rigidbody enemyRb;

        private GameObject player;

        private SpawnManager spawnManager;

        [SerializeField] private float speed = 3.0f;

        [SerializeField] private bool isBoss = false;
        [SerializeField] private float spawnInterval;
        private float nextSpawn;
        public int miniEnemySpawnCount;


        private void Start()
        {
            enemyRb = GetComponent<Rigidbody>();

            player = GameObject.Find("Player");

            if (isBoss)
                spawnManager = FindObjectOfType<SpawnManager>();
        }


        private void Update()
        {
            // make enemies chase the player
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);

            // spawn mini enemies
            if (isBoss)
            {
                if (Time.time > nextSpawn)
                {
                    nextSpawn = Time.time + spawnInterval;
                    spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
                }
            }

            // destroy entities out of bounds
            if (transform.position.y < -10)
                Destroy(gameObject);
        }
    }
}