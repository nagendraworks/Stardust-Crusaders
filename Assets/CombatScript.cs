 using UnityEngine;

public class CombatScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }
    void Attack()
    {

    }
}
