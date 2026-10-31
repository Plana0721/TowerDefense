using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int health = 10;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int damage)
    {
        health-=damage;
        if (health < 0) health = 0;
        UpdateUI();
        Debug.Log("玩家受伤，剩余血量：" + health);
        if (health <= 0)
        {
            GameOver();
        }
    }

    void Start()
    {
        UpdateUI();
        if(gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    void UpdateUI()
    {
        if(healthText.text != null)
        {
            healthText.text = "Health:" + health;
        }
        
    }
    void GameOver()
    {
        Debug.Log("游戏结束");
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }
        Time.timeScale = 0f;
    }
}
