using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  //敌人预制体
    public Transform spawnPoint;    //出生点
    public float spawnInterval = 2f;    //生成间隔
    public int enemiesPerWave = 3;  //单波次数量
    private float timer = 0f;   //计时器
    private int spawned = 0;    //已生成数量
    private int wave = 1;   //当前波次
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawned< enemiesPerWave)
        {
            //正在出怪
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnEnemy();
                spawned++;

            }
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= spawnInterval)
            {
                timer = 0f;
                wave++;
                spawned = 0;
                Debug.Log("第" + wave + "波开始！");
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        newEnemy.GetComponent<EnemyMovement>().waypoints = waypoints;
    }
}
