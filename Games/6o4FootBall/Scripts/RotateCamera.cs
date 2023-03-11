using UnityEngine;

namespace challenge4
{
    public class RotateCamera : MonoBehaviour
    {
        private float speed = 200;


        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

            transform.position = GameObject.Find("Player").transform.position; // Move focal point with player
        }
    }
}