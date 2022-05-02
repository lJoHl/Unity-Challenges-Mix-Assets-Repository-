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

            Destroy(gameObject);
        }
        else
        {
            GetComponent<AnimalHungerBar>().FeedAnimal(1);

            Destroy(other.gameObject);
        }
    }
}
