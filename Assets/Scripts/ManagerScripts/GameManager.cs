using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public AnimationManager animationManager;
    [SerializeField] public AudioManager audioManager;
    [SerializeField] public PowerUpSpawner spawner;
    [SerializeField] public InputManager inputManager;
    [SerializeField] public LightingManager lightingManager;
    [SerializeField] public SaveManager saveManager;
    [SerializeField] public UIManager uiManager;
    [SerializeField] public ScenesManager scenesManager;
    [SerializeField] public int waveNum = 1;
    [SerializeField] public bool waveIncrease = false;
    [SerializeField] public int killCount;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text waveText;
    [SerializeField] public TMP_Text timerText;
    [SerializeField] public int enemiesAlive = 0;
    [SerializeField] public float ct = 0;
    [SerializeField] public float waveTimer = 15;

    private void Awake()
    {
        waveNum = 1;
        ct = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("EnemySpawner").GetComponent<PowerUpSpawner>();
        killCount = 0;
        waveNum = 1;
        waveTimer = 15f;
        scoreText.text = "Bounties: " + killCount;
        timerText.text = "Time: " + ct;
        waveText.text = "Next Wave In: " + waveTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        waveTimer -= Time.deltaTime;
        timerText.text = "Next Wave In: " + Mathf.Floor(waveTimer);
        if (enemiesAlive < 0)
        {
            enemiesAlive = 0;
        }
        if ( enemiesAlive == 0 || waveTimer <= 0)
        {
            IncreaseWaveNumber();
        }
        scoreText.text = "Bounties: " + killCount;
        waveText.text = "Wave: " + waveNum;
        
      
        if (enemiesAlive == 0 || waveTimer <= 0)
        {
             if (enemiesAlive == 0 && waveNum % 2 == 0 || waveTimer <=0 && waveNum % 2 ==0)
            {
                spawner.SpawnBoss();
            }

            spawner.SpawnEnemies();
           
        }
        if (waveTimer < 0) {
            waveTimer = 15f;
        }

    }
    public void AddEnemy()
    {
        enemiesAlive++;
        Debug.Log("current amount alive " + (enemiesAlive));
        //Debug.Log("Enemies" + (enemiesAlive - 1));
    }
    public void RemoveEnemy()
    {
        enemiesAlive--;
        Debug.Log("current amount alive " + (enemiesAlive));
        //Debug.Log("Enemies" + enemiesAlive);
    }

    public void IncreaseWaveNumber()
    {
        waveNum++;
    }

    public void DeathScene()
    {
        SceneManager.LoadScene("Death Screen");
    }
}
