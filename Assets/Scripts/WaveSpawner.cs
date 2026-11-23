using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  //敌人预制体
    public Transform spawnPoint;    //出生点
    public float spawnInterval = 1.5f;    //生成间隔
    public float waveInterval = 3f;     //每波间隔
    public int baseEnemies = 3;     //基准敌人数量
    public int enmiesGrowth = 1;    //每波敌人增长数
    public float baseHealth = 3f;   //敌人基准血量
    public float healthGrowth = 1f;     //每波敌人血量增长数
    public TextMeshProUGUI waveText;    //波次文本
    public TextMeshProUGUI gameOverText;    //游戏结束文本
    public int maxWaves = 10;   //总波次
    private float timer = 0f;   //计时器
    private int spawned = 0;    //已生成数量
    private int wave = 1;   //当前波次
    private bool gameWon = false;   //游戏胜利标识
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        UpdateWaveUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWon) return;

        int waveCount = baseEnemies + enmiesGrowth*(wave - 1);

        if (wave >= maxWaves && spawned >= waveCount)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Win();
            }
            return;
        }
        if(spawned< waveCount)
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
            if(timer >= waveInterval)
            {
                timer = 0f;
                wave++;
                spawned = 0;
                Debug.Log("第" + wave + "波开始！敌人数量："+ (baseEnemies + enmiesGrowth * (wave - 1)));
                UpdateWaveUI();
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        newEnemy.GetComponent<EnemyMovement>().waypoints = waypoints;
        EnemyHealth health = newEnemy.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.health = baseHealth + healthGrowth * (wave - 1);
        }
    }
    void UpdateWaveUI()
    {
        if(waveText!=null)
        {
            waveText.text = "Wave:" + wave + "/" + maxWaves;
        }
    }
    void Win()
    {
        gameWon = true;
        Debug.Log("胜利！所有波次已清空！");

        if( gameOverText != null)
        {
            gameOverText.text = "You Win!";
            gameOverText.gameObject.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
