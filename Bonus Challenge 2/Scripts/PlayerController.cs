using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10;

    public float xLimit = 20;
    public float zTopLimit = 5;
    public float zLowerLimit = -1;

    public GameObject projectile;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x < -xLimit)
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);

        if (transform.position.x > xLimit)
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);


        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.z < zLowerLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerLimit);

        if (transform.position.z > zTopLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopLimit);



        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
