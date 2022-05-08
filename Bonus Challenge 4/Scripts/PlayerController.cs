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


        void Start()
        {
            playerRb = GetComponent<Rigidbody>();

            focalPoint = GameObject.Find("FocalPoint");
        }


        void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.52f, 0);
            //powerupIndicator.SetActive(hasPowerup ? true : false);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;

                Destroy(other.gameObject);

                powerupIndicator.gameObject.SetActive(true); //remplazar por un ternario

                StartCoroutine(PowerupCountdownRoutine());
            }
        }


        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false); //remplazar por un ternario
        }


        private void OnCollisionEnter(Collision collision)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            if (collision.gameObject.CompareTag("Enemy") & hasPowerup)
            {
                enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

                Debug.Log($"Collided with {collision.gameObject.name} with powerup set to {hasPowerup}");
            }
        }
    }
}