using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    [SerializeField] public float healthAmount;
    [SerializeField] public Health playerHealthReference;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthAmount = playerHealthReference.currentHealth;
        healthBar.fillAmount = healthAmount / 100;
    }
}
