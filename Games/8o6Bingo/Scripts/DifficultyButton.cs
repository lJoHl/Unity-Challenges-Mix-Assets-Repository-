using UnityEngine;
using UnityEngine.UI;

namespace challenge5
{
    public class DifficultyButton : MonoBehaviour
    {
        private Button button;

        private GameManager gameManagerX;

        [SerializeField] private int difficulty;


        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SetDifficulty);

            gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }


        // Set the difficulty of the game
        public void SetDifficulty()
        {
            gameManagerX.StartGame(difficulty);
        }
    }
}