using UnityEngine;

public class navigationScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void gameStart()
    {
        // Load the scene with the name "Game"
        UnityEngine.SceneManagement.SceneManager.LoadScene("level 1");
    }
    public void credits()
    {
        // Load the scene with the name "Game"
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScreen");
    }
    public void Abandon()
    {
        // Load the scene with the name "Game"
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
