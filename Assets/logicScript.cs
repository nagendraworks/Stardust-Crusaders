using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI; // For UI management

public class logicScript : MonoBehaviour
{
    public static logicScript instance; // Singleton instance
    public GameObject gameOverScreen;
    public Button restartButton; // Reference to the restart button UI
    public string sceneName = "MainScene"; // Replace with your actual scene name

    void Awake()
    {
        // Enforce the Singleton pattern (only one instance of logicScript in the scene)
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called once before the first frame update
    void Start()
    {
        // Initialize the restart button with the OnClick function
      
    }

    // Function to trigger the game over state
    public void GameOver()
    {
        // Show the game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    // Function to restart the game
    public void RestartGame()
    {
        // Reload the current scene (restart the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
