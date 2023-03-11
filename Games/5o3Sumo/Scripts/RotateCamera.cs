using UnityEngine;

namespace bonusChallenge4
{
    public class RotateCamera : MonoBehaviour
    {
        public float rotationSpeed;


        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);
        }
    }
}