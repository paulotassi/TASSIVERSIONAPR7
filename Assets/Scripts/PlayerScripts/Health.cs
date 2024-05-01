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
    public Health player;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Health>();

    }
    void Start()
    {
        currentHealth = maxHealth;
        // tell gm add enemy
    }

    public void Update()
    {
        if ( player.currentHealth <=0)
        {
            manager.DeathScene();
        }
        if (currentHealth <= 0)
        {
            Death();
            //Play Dead Animation
            //Set isDead = true;
            //Lock Player control
            //Activate Respawn or Return to Title Canvas
        }
    }
    public void takeDamage(int amount)
    {
        currentHealth -= amount;

    }

    public void Death()
    {
            manager.killCount++;
            manager.RemoveEnemy();
            Destroy(gameObject);
    }

}
