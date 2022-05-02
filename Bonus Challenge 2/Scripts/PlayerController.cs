using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private float speed = 10;

    private float xLimit = 20;
    private float zTopLimit = 5;
    private float zLowerLimit = -1;

    public GameObject projectile;

    
    private void Update()
    {
        // allows the player to move horizontally within set limits
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x < -xLimit)
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);

        if (transform.position.x > xLimit)
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);


        // allows the player to move vertically within set limits
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.z < zLowerLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerLimit);

        if (transform.position.z > zTopLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopLimit);


        // allows the player to throw food by pressing the space key
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
