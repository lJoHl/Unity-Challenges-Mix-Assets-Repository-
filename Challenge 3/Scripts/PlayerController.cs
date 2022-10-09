using UnityEngine;

namespace Challenge3
{
    public class PlayerController : MonoBehaviour
    {
        public bool gameOver;

        private float floatForce = 50;
        private float gravityModifier = 1.5f;
        private Rigidbody playerRb;

        public ParticleSystem explosionParticle;
        public ParticleSystem fireworksParticle;

        private AudioSource playerAudio;
        public AudioClip moneySound;
        public AudioClip explodeSound;
        public AudioClip bounceSound;


        private void Start()
        {
            Physics.gravity *= gravityModifier;

            playerRb = GetComponent<Rigidbody>();
            // Apply a small upward force at the start of the game
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

            playerAudio = GetComponent<AudioSource>();
        }


        private void Update()
        {
            // while space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space) & !gameOver)
                playerRb.AddForce(Vector3.up * floatForce);
        }


        private void OnCollisionEnter(Collision other)
        {
            switch (other.gameObject.tag)
            {
                // if player collides with bomb, explode and set gameOver to true
                case "Bomb":
                    explosionParticle.Play();
                    playerAudio.PlayOneShot(explodeSound, 1.0f);

                    gameOver = true;
                    Debug.Log("Game Over!");

                    Destroy(other.gameObject);
                    break;

                // if player collides with money, fireworks
                case "Money":
                    fireworksParticle.Play();
                    playerAudio.PlayOneShot(moneySound, 1.0f);

                    Destroy(other.gameObject);
                    break;

                // if player collides with ground, bounce
                case "Ground":
                    if (!gameOver)
                    {
                        playerAudio.PlayOneShot(bounceSound, 1.0f);

                        playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                    }
                    break;
            }
        }
    }
}