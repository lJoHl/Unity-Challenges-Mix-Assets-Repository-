using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private UI UIInDC;


    // Start is called before the first frame update
    private void Start()
    {
        UIInDC = GameObject.Find("UserInterface").GetComponent<UI>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            UIInDC.lives--;

            Debug.Log($"Lives: {UIInDC.lives}");
        }
        else
        {
            UIInDC.score++;

            Debug.Log($"Score: {UIInDC.score}");

            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
