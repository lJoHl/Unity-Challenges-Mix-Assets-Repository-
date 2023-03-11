using UnityEngine;

namespace challenge4
{
    public class Enemy : MonoBehaviour
    {
        private GameObject playerGoal;

        private Rigidbody enemyRb;

        public float speed;


        private void Start()
        {
            enemyRb = GetComponent<Rigidbody>();

            playerGoal = GameObject.Find("Player Goal");
        }


        private void Update()
        {
            // Set enemy direction towards player goal and move there
            Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            // If enemy collides with either goal, destroy it
            if (other.gameObject.name == "Enemy Goal")
            {
                Destroy(gameObject);
            }
            else if (other.gameObject.name == "Player Goal")
            {
                Destroy(gameObject);
            }

        }

    }
}