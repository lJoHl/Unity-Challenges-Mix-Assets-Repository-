using UnityEngine;

namespace bonusChallenge4
{
    public class RocketBehaviour : MonoBehaviour
    {
        private Transform target;
        private bool homing;

        private float aliveTimer = 5.0f;

        private float speed = 15.0f;
        private float rocketStrength = 15.0f;


        // Make rockets chase targets
        private void Update()
        {
            if (homing && target != null)
            {
                Vector3 moveDirection = (target.transform.position - transform.position).normalized;
                transform.position += moveDirection * speed * Time.deltaTime;
                transform.LookAt(target);
            }
        }


        // Active rockets behaviour
        public void Fire(Transform homingTarget)
        {
            target = homingTarget;
            homing = true;

            Destroy(gameObject, aliveTimer);
        }


        // Push target at collision with it
        private void OnCollisionEnter(Collision col)
        {
            if (target != null)
            {
                if (col.gameObject.CompareTag(target.tag))
                {
                    Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>();
                    Vector3 away = -col.contacts[0].normal;

                    targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);

                    Destroy(gameObject);
                }
            }
        }
    }
}