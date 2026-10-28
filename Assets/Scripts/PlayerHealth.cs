using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int health = 10;

    void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int damage)
    {
        health-=damage;
        Debug.Log("玩家受伤，剩余血量：" + health);
        if (health <= 0)
        {
            Debug.Log("游戏结束");
        }
    }
  
}
