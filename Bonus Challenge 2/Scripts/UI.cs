using UnityEngine;

public class UI : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;


    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log($"Lives: {lives}");
        Debug.Log($"Score: {score}");
    }

    // Update is called once per frame
    private void Update()
    {
        if (lives <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0; 
        }
    }
}
