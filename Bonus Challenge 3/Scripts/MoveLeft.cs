using UnityEngine;

namespace bonusChallenge3
{
    public class MoveLeft : MonoBehaviour
    {
        private PlayerController playerControllerScript;

        private float speed;
        private float dashSpeed;

        private float leftBound = -15;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

            speed = 30;
            dashSpeed = speed * 2;
        }


        private void Update()
        {
            if (!playerControllerScript.gameOver)
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            // controls speed value
            speed = (playerControllerScript.usingDash) ? dashSpeed : speed;

            // destroy just obstacles out of bounds
            if (transform.position.x < leftBound & gameObject.CompareTag("Obstacle"))
                Destroy(gameObject);
        }
    }
}