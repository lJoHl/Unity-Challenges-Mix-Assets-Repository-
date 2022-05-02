using UnityEngine;

public class UI : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;


    private void Start()
    {
        Debug.Log($"Lives: {lives}");
        Debug.Log($"Score: {score}");
    }


    // Game over if lives run out
    private void Update()
    {
        if (lives <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0; 
        }
    }
}
