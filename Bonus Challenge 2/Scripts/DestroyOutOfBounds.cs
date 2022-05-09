using UnityEngine;

namespace BonusChallenge2
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        private float topBound = 20;
        private float lowerBound = -3;
        private float lateralBound = 20;


        // Eliminate objects that go out of the limits of the screen
        private void Update()
        {
            if (transform.position.z > topBound | transform.position.z < lowerBound | transform.position.x < -lateralBound | transform.position.x > lateralBound)
                Destroy(gameObject);
        }
    }
}