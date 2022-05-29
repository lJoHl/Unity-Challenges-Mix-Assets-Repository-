using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BonusChallenge5
{
    public class Target : MonoBehaviour
    {
        private GameManager gameManager;

        public ParticleSystem explosionParticle;

        private Rigidbody targetRb;

        private float minSpeed = 12;
        private float maxSpeed = 16;

        private float maxTorque = 10;

        private float xRange = 4;
        private float ySpawnPos = -2;

        public int pointValue;


        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            targetRb = GetComponent<Rigidbody>();

            targetRb.AddForce(RandomForce(), ForceMode.Impulse);
            targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

            transform.position = RandomSpawnPos();
        }

        private void Update()
        {

        }

        /*
        private void OnMouseDown()
        {
            if (gameManager.isGameActive)
            {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

                gameManager.UpdateScore(pointValue);
            }
        }
        */

        private void OnTriggerEnter(Collider other)
        {
            if (!gameObject.CompareTag("Bad") & gameManager.isGameActive)
                gameManager.UpdateLives(-1);

            Destroy(gameObject);
        }


        public void DestroyTarget()
        {
            if (gameManager.isGameActive)
            {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                gameManager.UpdateScore(pointValue);
            }
        }


        Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minSpeed, maxSpeed);
        }

        float RandomTorque()
        {
            return Random.Range(-maxTorque, maxTorque);
        }

        Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        }
    }
}