using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bonusChallenge4
{
    public class Enemy : MonoBehaviour
    {
        private Rigidbody enemyRb;

        private GameObject player;

        [SerializeField] private float speed = 3.0f;

        public bool isBoss = false;
        public float spawnInterval;
        private float nextSpawn;
        public int miniEnemySpawnCount;
        private SpawnManager spawnManager;



        private void Start()
        {
            enemyRb = GetComponent<Rigidbody>();

            player = GameObject.Find("Player");

            if (isBoss)
                spawnManager = FindObjectOfType<SpawnManager>();
        }


        private void Update()
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            enemyRb.AddForce(lookDirection * speed);

            if (isBoss)
            {
                if (Time.time > nextSpawn)
                {
                    nextSpawn = Time.time + spawnInterval;
                    spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
                }
            }

            if (transform.position.y < -10)
                Destroy(gameObject);
        }
    }
}