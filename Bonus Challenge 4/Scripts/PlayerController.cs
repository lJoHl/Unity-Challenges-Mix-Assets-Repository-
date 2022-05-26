using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bonusChallenge4
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;

        private GameObject focalPoint;

        public float speed = 5.0f;

        public bool hasPowerup = false;

        private float powerupStrength = 15.0f;
        public GameObject powerupIndicator;
        public PowerUpType currentPowerUp = PowerUpType.None;
        public GameObject rocketPrefab;
        private GameObject tmpRocket;
        private Coroutine powerupCountdown;

        public float hangTime;
        public float smashSpeed;
        public float explosionForce;
        public float explosionRadius;
        private bool smashing = false;
        private float floorY;


        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();

            focalPoint = GameObject.Find("FocalPoint");
        }


        private void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.52f, 0);
            //powerupIndicator.SetActive(hasPowerup ? true : false);

            if (currentPowerUp == PowerUpType.Rockets && Input.GetKeyDown(KeyCode.F))
                LaunchRockets();

            if (currentPowerUp == PowerUpType.Smash & Input.GetKeyDown(KeyCode.Space) & !smashing)
            {
                smashing = true;
                StartCoroutine(Smash());
            }

        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;

                Destroy(other.gameObject);

                powerupIndicator.gameObject.SetActive(true); //remplazar por un ternario

                if (powerupCountdown != null)
                {
                    StopCoroutine(powerupCountdown);
                }
                powerupCountdown = StartCoroutine(PowerupCountdownRoutine());
            }
        }


        private IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            currentPowerUp = PowerUpType.None;
            powerupIndicator.gameObject.SetActive(false); //remplazar por un ternario
        }


        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            if (collision.gameObject.CompareTag("Enemy") & currentPowerUp == PowerUpType.Pushback)
            {
                enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

                Debug.Log("Player collided with: " + collision.gameObject.name + " withpowerup set to " + currentPowerUp.ToString());
            }
        }


        private void LaunchRockets()
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
                tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
            }
        }


        private IEnumerator Smash()
        {
            var enemies = FindObjectsOfType<Enemy>();
            //Store the y position before taking off
            floorY = transform.position.y;
            //Calculate the amount of time we will go up
            float jumpTime = Time.time + hangTime;
            while (Time.time < jumpTime)
            {
                //move the player up while still keeping their x velocity.
                playerRb.velocity = new Vector2(playerRb.velocity.x, smashSpeed);
                yield return null;
            }
            //Now move the player down
            while (transform.position.y > floorY)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, -smashSpeed * 2);
                yield return null;
            }
            //Cycle through all enemies.
            for (int i = 0; i < enemies.Length; i++)
            {
                //Apply an explosion force that originates from our position.
                if (enemies[i] != null)
                    enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce,
                    transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
            }
            //We are no longer smashing, so set the boolean to false
            smashing = false;
        }
    }
}