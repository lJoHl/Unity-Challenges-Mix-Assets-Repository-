using UnityEngine;
using UnityEngine.UI;

public class AnimalHungerBar : MonoBehaviour
{
    public Slider animalHungerSlider;
    public int amountToBeFed;

    private int currentFedAmount = 0;

    private UI UIInAHB;

    // Start is called before the first frame update
    private void Start()
    {
        animalHungerSlider.maxValue = amountToBeFed;
        animalHungerSlider.value = 0;
        animalHungerSlider.fillRect.gameObject.SetActive(false);

        UIInAHB = GameObject.Find("UserInterface").GetComponent<UI>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


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
