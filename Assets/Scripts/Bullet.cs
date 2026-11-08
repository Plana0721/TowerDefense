using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float damage = 1f;
    private Transform target;
    public void SetTarget(Transform t)
    {
        target = t;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position =Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //飞向目标
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            EnemyHealth enemy = target.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);

            }
            Destroy(gameObject);
        }
    }
}
