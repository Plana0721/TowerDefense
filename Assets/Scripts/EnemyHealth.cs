using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3f;   //血量
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("敌人出生，血量：" + health);
    }

    public void TakeDamage(float damage)
    {
        health-=damage;
;       Debug.Log("敌人受伤，剩余血量：" + health);

        if (health <= 0)
        {
            Debug.Log("敌人死亡");
            Destroy(gameObject);
        }

    }
   
}
