using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30;
    public float lowerBound = -10;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.z > topBound)
            Destroy(gameObject);

        if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");

            Destroy(gameObject);
        }
    }
}
