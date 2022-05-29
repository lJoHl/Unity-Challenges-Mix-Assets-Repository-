using UnityEngine;
using UnityEngine.UI;

namespace BonusChallenge5
{
    public class DifficultyButton : MonoBehaviour
    {
        private GameManager gameManager;

        private Button button;

        [SerializeField] private int difficulty;


        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            button = GetComponent<Button>();
            button.onClick.AddListener(SetDifficulty);
        }


        private void SetDifficulty()
        {
            gameManager.StartGame(difficulty);
        }
    }
}