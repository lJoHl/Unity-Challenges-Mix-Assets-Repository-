using UnityEngine;

namespace bonusChallenge3
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
        
        private Animator playerAnim;

        [SerializeField] private ParticleSystem explosionParticle; 
        [SerializeField] private ParticleSystem dirtParticle; 

        private AudioSource playerAudio;
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip crashSound;

        [SerializeField] private float jumpForce;
        [SerializeField] private float gravityModifier;

        public bool isOnGround;
        public bool gameOver;

        private bool hasJumpOnce;
        private bool hasJumpTwice;

        public bool usingDash;


        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();

            playerAnim = GetComponent<Animator>();

            playerAudio = GetComponent<AudioSource>();

            Physics.gravity *= gravityModifier;
        }


        private void Update()
        {
            // makes player jump
            if (Input.GetKeyDown(KeyCode.Space) & isOnGround & !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);

                isOnGround = false;
            }

            // allow the player to jump twice
            if (Input.GetKeyUp(KeyCode.Space) & !isOnGround)
                hasJumpOnce = true;

            // makes player jump a second time
            if (Input.GetKeyDown(KeyCode.Space) & hasJumpOnce == true & hasJumpTwice == false & !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);

                playerAnim.Play("Running_Jump", 3, 0);
                playerAudio.PlayOneShot(jumpSound, 1.0f);

                hasJumpTwice = true;
            }

            // allows the player to use a dash to increase it speed, and decrease it when the player is not using it
            if (Input.GetKey(KeyCode.C) & isOnGround & !gameOver)
            {
                playerAnim.SetFloat("Speed_f", 2);
                usingDash = true;
            }
            else
            {
                playerAnim.SetFloat("Speed_f", 1);
                usingDash = false;
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (!gameOver)
            {
                switch(collision.gameObject.tag)
                {
                    case "Ground":
                        dirtParticle.Play();
                        isOnGround = true;

                        hasJumpOnce = false;
                        hasJumpTwice = false;
                        break;

                    case "Obstacle":
                        gameOver = true;
                        Debug.Log("Game Over!");

                        playerAnim.SetBool("Death_b", true);
                        playerAnim.SetInteger("DeathType_int", 1);
                        explosionParticle.Play();
                        dirtParticle.Stop();
                        playerAudio.PlayOneShot(crashSound, 1.0f);
                        break;
                }
            }
        }
    }
}