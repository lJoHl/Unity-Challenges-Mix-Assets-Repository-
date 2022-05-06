using UnityEngine;

namespace bonusChallenge3
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;

        private Animator playerAnim;

        public ParticleSystem explosionParticle; // se puede hacer privado?
        public ParticleSystem dirtParticle; // se puede hacer privado?

        private AudioSource playerAudio;

        public AudioClip jumpSound;
        public AudioClip crashSound;

        public float jumpForce;
        public float gravityModifier;

        public bool isOnGround;
        public bool gameOver;


        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();

            playerAnim = GetComponent<Animator>();

            playerAudio = GetComponent<AudioSource>();

            Physics.gravity *= gravityModifier;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) & isOnGround & !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                playerAnim.SetTrigger("Jump_trig");

                dirtParticle.Stop();

                playerAudio.PlayOneShot(jumpSound, 1.0f);

                isOnGround = false;
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            // usar un switch en esta parte
            if (collision.gameObject.CompareTag("Ground")) // las particulas de correr salen si tocas el suelo luego de golpear una valla, arreglar con la variable gameOver
            {
                dirtParticle.Play();

                isOnGround = true;
            }


            if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over!");

                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);

                explosionParticle.Play();

                dirtParticle.Stop(); // SetACtive(false) evitara el error de las particulas activadas aun al perder

                playerAudio.PlayOneShot(crashSound, 1.0f);
            }
        }
    }
}