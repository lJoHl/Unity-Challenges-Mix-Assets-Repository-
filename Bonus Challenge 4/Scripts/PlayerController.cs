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

    }
}