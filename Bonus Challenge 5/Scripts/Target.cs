using UnityEngine;

namespace BonusChallenge5
{
    public class Target : MonoBehaviour
    {
        private GameManager gameManager;

        private Rigidbody targetRb;

        [SerializeField] private ParticleSystem explosionParticle;

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


        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minSpeed, maxSpeed);
        }

        private float RandomTorque()
        {
            return Random.Range(-maxTorque, maxTorque);
        }

        private Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        }


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
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

                gameManager.UpdateScore(pointValue);

                Destroy(gameObject);
            }
        }
    }
}