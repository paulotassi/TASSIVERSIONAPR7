using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 5;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            Debug.Log("DEAD Thing");
            Destroy(gameObject);
        //Play Dead Animation
        //Set isDead = true;
        //Lock Player control
        //Activate Respawn or Return to Title Canvas
        }
    }

}
