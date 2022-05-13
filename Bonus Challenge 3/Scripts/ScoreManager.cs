using UnityEngine;

namespace bonusChallenge3
{
    public class ScoreManager : MonoBehaviour
    {
        private int score = 0;

        private PlayerController playerControllerScript;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }


        private void Update()
        {
            if (!playerControllerScript.gameOver)
            {
                score += (playerControllerScript.usingDash) ? 2 : 1;

                Debug.Log($"Score: {score}");
            }
                
        }
    }
}