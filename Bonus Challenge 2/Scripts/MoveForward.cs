using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveForwardSpeed = 10;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveForwardSpeed);
    }
}
