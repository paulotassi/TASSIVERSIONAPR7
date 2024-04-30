using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BossHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 5;
    public int currentHealth;
    public bool shieldStatus = true;
    public GameObject shieldMesh;
    public GameManager manager;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        shieldStatus = true;
        shieldMesh.SetActive(true);
    }
    void Start()
    {
        currentHealth = maxHealth;
        manager.AddEnemy();
        // tell gm add enemy
    }

    public void BreakShield()
    {
        shieldStatus = false;
        shieldMesh.SetActive(false);
    }
    public void takeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            Debug.Log("DEAD Boss");
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
