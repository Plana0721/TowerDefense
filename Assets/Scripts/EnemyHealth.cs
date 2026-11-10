using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3f;   //血量
    private Renderer rend;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor=rend.material.color;
        Debug.Log("敌人出生，血量：" + health);
    }

    public void TakeDamage(float damage)
    {
        health-=damage;
        StartCoroutine(FlashRed());
;       Debug.Log("敌人受伤，剩余血量：" + health);

        if (health <= 0)
        {
            if (EconomyManager.Instance!= null)
            {
                EconomyManager.Instance.AddMoney(10);
            }
            Debug.Log("敌人死亡");
            Destroy(gameObject);
        }

    }
   IEnumerator FlashRed()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColor;
    }
}
