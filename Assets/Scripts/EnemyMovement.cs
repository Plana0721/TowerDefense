using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour

{
    public Transform[] waypoints;
    public float speed = 3f;
    public int currentindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = waypoints[currentindex].position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
        if(currentindex < waypoints.Length-1 && Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentindex++;
        }
        if (currentindex >= waypoints.Length - 1 && Vector3.Distance(transform.position, target) < 0.1f)
        {
            Debug.Log("敌人到达终点！");
            if (PlayerHealth.Instance != null)
            {
                PlayerHealth.Instance.TakeDamage(1);
            }
            
            Destroy(gameObject);
        }
    }
}
