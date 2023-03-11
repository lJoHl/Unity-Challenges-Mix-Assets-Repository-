using UnityEngine;
using UnityEngine.UI;

namespace BonusChallenge2
{
    public class AnimalHungerBar : MonoBehaviour
    {
        public Slider animalHungerSlider;
        public int amountToBeFed;

        private int currentFedAmount = 0;

        private UI UIInAHB;


        private void Start()
        {
            animalHungerSlider.maxValue = amountToBeFed;
            animalHungerSlider.value = 0;
            animalHungerSlider.fillRect.gameObject.SetActive(false);

            UIInAHB = GameObject.Find("UserInterface").GetComponent<UI>();
        }


        // Increase the score by feeding an animal
        public void FeedAnimal(int amount)
        {
            currentFedAmount += amount;

            animalHungerSlider.fillRect.gameObject.SetActive(true);
            animalHungerSlider.value = currentFedAmount;

            if (currentFedAmount >= amountToBeFed)
            {
                UIInAHB.score += amountToBeFed;

                Debug.Log($"Score: {UIInAHB.score}");

                Destroy(gameObject, 0.1f);
            }
        }

    }
}