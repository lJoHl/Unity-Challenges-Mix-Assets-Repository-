using System.Collections;
using UnityEngine;

namespace challenge4
{
    public class PlayerController : MonoBehaviour
    {
        private GameObject focalPoint;

        private Rigidbody playerRb;

        private float speed = 500;

        private bool hasPowerup;
        [SerializeField] private GameObject powerupIndicator;
        [SerializeField] private int powerUpDuration = 5;

        private float normalStrength = 10; // how hard to hit enemy without powerup
        private float powerupStrength = 25; // how hard to hit enemy with powerup

        [SerializeField] private ParticleSystem turboBoostParticle;


        private void Start()
        {
            focalPoint = GameObject.Find("Focal Point");

            playerRb = GetComponent<Rigidbody>();
        }


        private void Update()
        {
            // Add force to player in direction of the focal point (and camera)
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

            // Set powerup indicator position to beneath player
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

            turboBoost();
        }


        // If Player collides with powerup, activate powerup
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                Destroy(other.gameObject);
                hasPowerup = true;
                powerupIndicator.SetActive(true);
                StartCoroutine(PowerupCooldown());
            }
        }


        // Coroutine to count down powerup duration
        private IEnumerator PowerupCooldown()
        {
            yield return new WaitForSeconds(powerUpDuration);
            hasPowerup = false;
            powerupIndicator.SetActive(false);
        }
 

        // If Player collides with enemy
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

                if (hasPowerup) // if have powerup hit enemy with powerup force
                    enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
                else // if no powerup, hit enemy with normal strength 
                    enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
        }


        private void turboBoost()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                speed = 1000;
                turboBoostParticle.Play();
            }
            else
            {
                speed = 500;
                turboBoostParticle.Stop();
            }
        }
    }
}