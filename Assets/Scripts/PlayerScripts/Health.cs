using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 5;
    public int currentHealth;
    public GameManager manager;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        manager.AddEnemy();
        // tell gm add enemy
    }
    public void takeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            Debug.Log("DEAD Thing");
            manager.killCount++;
            manager.RemoveEnemy();
            Destroy(gameObject);
        //Play Dead Animation
        //Set isDead = true;
        //Lock Player control
        //Activate Respawn or Return to Title Canvas
        }
    }

}
