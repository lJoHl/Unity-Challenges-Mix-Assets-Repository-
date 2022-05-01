using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30;
    public float lowerBound = -10;
    public float lateralBound = 25;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.z > topBound | transform.position.z < lowerBound | transform.position.x < -lateralBound | transform.position.x > lateralBound)
            Destroy(gameObject);
    }
}
