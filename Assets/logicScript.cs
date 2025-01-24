using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI; // For UI management

public class logicScript : MonoBehaviour
{
    public static logicScript instance; // Singleton instance
    public GameObject winScreen;
    public GameObject gameOverScreen;

    // Reference to the main character
    public GameObject mainCharacter;

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

    // Update is called once per frame
    void Update()
    {
        // Check if the MC's Y position is below -10
        if (mainCharacter.transform.position.y < -10f)
        {
            GameOver();
        }
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
    public void WinScreen()
    {
        // Show the game over screen
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
    }
}
