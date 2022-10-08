using UnityEngine;

namespace bonusChallenge3
{
    public class ScoreManager : MonoBehaviour
    {
        private PlayerController playerControllerScript;

        private int score = 0;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }


        private void Update()
        {
            // controls the increase of the score
            if (!playerControllerScript.gameOver)
            {
                score += (playerControllerScript.usingDash) ? 2 : 1;

                Debug.Log($"Score: {score}");
            }
        }
    }
}