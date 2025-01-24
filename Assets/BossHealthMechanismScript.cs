using UnityEngine;

public class BossHealthMechanismScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int health = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MC")
        {
            // Reduce the health of the enemy
            health -= 10;

            // Optionally, print the new health value to the console for debugging
            Debug.Log("Enemy Health: " + health);

            if (health <= 0)
            {
                // Destroy the enemy and trigger GameOver
                Destroy(gameObject);
                logicScript.instance.WinScreen(); // Call GameOver from the singleton logicScript
                Debug.Log("Enemy defeated!");
            }
        }
    }
}
