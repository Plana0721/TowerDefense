using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 5f;    //检测范围
    public float fireInterval = 0.5f;   //开火间隔
    private float fireTimer = 0f; //计时器
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);     //范围内命中目标
        Transform target = null;
        float minDistance = range;  //最近距离

        foreach (Collider item in hits) //遍历命中目标
        {
            if (item.CompareTag("Enemy")){
                float distance = Vector3.Distance(item.transform.position, transform.position); //计算目标距离
                if (distance < minDistance) //统计最近距离目标
                {
                    minDistance = distance;
                    target = item.transform;
                }
            }
        }

        if (target != null)
        {
            //转向
            Vector3 direction = target.position - transform.position;   //记录方向
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);

            //开火计时
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireInterval)
            {
                EnemyHealth enemy = target.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    Debug.Log("Fire!");
                    enemy.TakeDamage(1f);
                }
                else
                {
                    Debug.Log("目标敌人缺少EnemyHealth脚本");
                }
                fireTimer = 0f;
            }
        }
        else
        {
            fireTimer = 0f;
        }
    }
}
