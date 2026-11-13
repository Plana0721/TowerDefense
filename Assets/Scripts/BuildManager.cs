using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost = 50;  //建造费用
    public float groundY = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryBuildTower();
        }
    }
    void TryBuildTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit hit, 100f))
        {
            if (!hit.collider.CompareTag("Ground"))
            {
                Debug.Log("只能建立在地面上");
                return;
            }
            if (!EconomyManager.Instance.SpendMoney(towerCost))
            {
                return;
            }
            Vector3 pos = new Vector3(hit.point.x, groundY, hit.point.z);
            Instantiate(towerPrefab, pos, quaternion.identity);
            Debug.Log("建塔成功！" + pos);
        }
    }
}
