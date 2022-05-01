using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
            Debug.Log("Game Over");
        else
            Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
