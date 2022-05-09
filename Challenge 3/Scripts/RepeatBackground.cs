using UnityEngine;

namespace Challenge3
{
    public class RepeatBackground : MonoBehaviour
    {
        private Vector3 startPos;
        private float repeatWidth;


        private void Start()
        {
            startPos = transform.position; // establish the default starting position 
            repeatWidth = GetComponent<BoxCollider>().size.x / 2; // set repeat width to half of the background
        }


        private void Update()
        {
            // if background moves left by its repeat width, move it back to start position
            if (transform.position.x < startPos.x - repeatWidth)
                transform.position = startPos;
        }
    }
}