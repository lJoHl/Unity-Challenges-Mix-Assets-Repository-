using UnityEngine;

namespace BonusChallenge2
{
    public class DetectCollisions : MonoBehaviour
    {
        private UI UIInDC;


        private void Start()
        {
            UIInDC = GameObject.Find("UserInterface").GetComponent<UI>();
        }


        private void OnTriggerEnter(Collider other)
        {
            // takes a life from the player when being rammed by an animal
            if (other.gameObject.name == "Player")
            {
                UIInDC.lives--;

                Debug.Log($"Lives: {UIInDC.lives}");

                Destroy(gameObject);
            }
            else // fill the animal's hunger bar by colliding with food
            {
                GetComponent<AnimalHungerBar>().FeedAnimal(1);

                Destroy(other.gameObject);
            }
        }
    }
}