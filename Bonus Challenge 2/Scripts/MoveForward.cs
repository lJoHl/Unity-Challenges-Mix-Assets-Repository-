using UnityEngine;

namespace BonusChallenge2
{
    public class MoveForward : MonoBehaviour
    {
        private float moveForwardSpeed = 10;


        // Moves food forward
        private void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveForwardSpeed);
        }
    }
}