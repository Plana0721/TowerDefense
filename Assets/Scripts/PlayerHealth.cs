using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int health = 10;
    public TextMeshProUGUI healthText;
    void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int damage)
    {
        health-=damage;
        UpdateUI();
        Debug.Log("玩家受伤，剩余血量：" + health);
        if (health <= 0)
        {
            Debug.Log("游戏结束");
        }
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if(healthText.text != null)
        {
            healthText.text = "Health:" + health;
        }
        
    }
}
