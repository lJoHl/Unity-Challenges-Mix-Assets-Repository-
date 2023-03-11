using UnityEngine;

namespace Challenge3
{
    public class MoveLeft : MonoBehaviour
    {
        public float speed;

        private PlayerController playerControllerScript;

        private float leftBound = -10;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }


        private void Update()
        {
            // if game is not over, move to the left
            if (!playerControllerScript.gameOver)
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);


            // if object goes off screen that is NOT the background, destroy it
            if (transform.position.x < leftBound & !gameObject.CompareTag("Background"))
                Destroy(gameObject);
        }
    }
}