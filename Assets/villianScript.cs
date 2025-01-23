using UnityEngine;

public class villianScript : MonoBehaviour
{
    public float health = 100;

    void Start()
    {
        // Any initialization if needed
    }


    void Update()
    {
        // Any logic needed here (like enemy movement)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "character")
        {
            // Reduce the health of the enemy
            health -= 10;

            // Optionally, print the new health value to the console for debugging
            Debug.Log("Enemy Health: " + health);

            if (health <= 0)
            {
                // Destroy the enemy and trigger GameOver
                Destroy(gameObject);
                logicScript.instance.GameOver(); // Call GameOver from the singleton logicScript
                Debug.Log("Enemy defeated!");
            }
        }
    }
}
