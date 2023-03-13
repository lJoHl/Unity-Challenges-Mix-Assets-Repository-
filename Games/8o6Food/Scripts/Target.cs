using System.Collections;
using UnityEngine;

namespace challenge5
{
    public class Target : MonoBehaviour
    {
        private Rigidbody rb;

        private GameManager gameManager;

        public GameObject explosionFx;

        [SerializeField] private int pointValue;

        private float timeOnScreen = 1.0f;

        public float timeWhenSpawned;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

            timeWhenSpawned = Time.time; 

            StartCoroutine(RemoveObjectRoutine());
        }


        // Sets game behavior, when target is clicked
        private void OnMouseDown()
        {
            if (gameManager.isGameActive)
            {
                gameManager.UpdateScore(pointValue);

                Explode();
                Destroy(gameObject);
            }
        }


        // Display explosion particle at object's position
        private void Explode()
        {
            Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        }


        // After a delay, destroys the target
        private IEnumerator RemoveObjectRoutine()
        {
            yield return new WaitForSeconds(timeOnScreen);

            if (gameManager.isGameActive)
            {
                if (!gameObject.CompareTag("Bad"))
                    gameManager.GameOver();
                
                Destroy(gameObject);
            }
        }


        // Prevents two targets from being within the same space
        private void OnTriggerEnter(Collider other)
        {
            float timeDifference = timeWhenSpawned - other.GetComponent<Target>().timeWhenSpawned;

            if (timeDifference < 0)
                Destroy(gameObject);
        }
    }
}