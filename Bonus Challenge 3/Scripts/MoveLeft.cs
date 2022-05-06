using UnityEngine;

namespace bonusChallenge3
{
    public class MoveLeft : MonoBehaviour
    {
        private float speed = 30;

        private PlayerController playerControllerScript; //renombrar como PCInMV

        private float leftBound = -15;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }


        private void Update()
        {
            if (playerControllerScript.gameOver == false) // cambiar por !playerControllerScript.gameOver
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            // if (!GameObject.Find("Player").GetComponent<PlayerController>().gameOver)
            //      transform.Translate(Vector3.left * Time.deltaTime * speed);


            if (transform.position.x < leftBound & gameObject.CompareTag("Obstacle"))
                Destroy(gameObject);
        }
    }
}