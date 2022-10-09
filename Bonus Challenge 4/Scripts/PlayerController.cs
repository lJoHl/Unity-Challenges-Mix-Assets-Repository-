using System.Collections;
using UnityEngine;

namespace bonusChallenge4
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;

        private GameObject focalPoint;

        [SerializeField] private float speed = 5.0f;

        private bool hasPowerup = false;

        [SerializeField] private GameObject powerupIndicator;
        private PowerUpType currentPowerUp = PowerUpType.None;
        private Coroutine powerupCountdown;
        private float powerupStrength = 15.0f;

        [SerializeField] private GameObject rocketPrefab;
        private GameObject tmpRocket;

        [SerializeField] private float hangTime;
        [SerializeField] private float smashSpeed;
        [SerializeField] private float explosionForce;
        [SerializeField] private float explosionRadius;
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

            // allows active a powerup based on its type
            switch (currentPowerUp)
            {
                case PowerUpType.Rockets:
                    if (Input.GetKeyDown(KeyCode.F))
                        LaunchRockets();
                    break;

                case PowerUpType.Smash:
                    if (Input.GetKeyDown(KeyCode.Space) & !smashing)
                    {
                        smashing = true;
                        StartCoroutine(Smash());
                    }
                    break;
            }
        }


        // Active powerup effects
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;

                Destroy(other.gameObject);
                powerupIndicator.gameObject.SetActive(true);

                if (powerupCountdown != null)
                    StopCoroutine(powerupCountdown);
                powerupCountdown = StartCoroutine(PowerupCountdownRoutine());
            }
        }


        // Disable powerup effect after awhile
        private IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);

            hasPowerup = false;
            currentPowerUp = PowerUpType.None;
            powerupIndicator.gameObject.SetActive(false);
        }


        // Establish the behaviour of pushback powerup
        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            if (collision.gameObject.CompareTag("Enemy") & currentPowerUp == PowerUpType.Pushback)
                enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }


        // Establish the behaviour of rockets powerup and its target
        private void LaunchRockets()
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
                tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
            }
        }


        // Establish the behaviour of smash powerup
        private IEnumerator Smash()
        {
            var enemies = FindObjectsOfType<Enemy>();

            floorY = transform.position.y;  // store the y position before taking off
            float jumpTime = Time.time + hangTime;  // calculate the amount of time we will go up

            // move the player up while still keeping their x velocity.
            while (Time.time < jumpTime)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, smashSpeed);
                yield return null;
            }

            // move the player down
            while (transform.position.y > floorY)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, -smashSpeed * 2);
                yield return null;
            }

            // apply an explosion force that originates from our position.
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                    enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
            }

            smashing = false;
        }
    }
}