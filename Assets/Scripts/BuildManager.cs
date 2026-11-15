using Unity.Mathematics;
using UnityEditor;
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
            //判断地面
            if (!hit.collider.CompareTag("Ground"))
            {
                Debug.Log("只能建立在地面上");
                return;
            }
            //对齐整数格
            Vector3 pos = new Vector3(hit.point.x, groundY, hit.point.z);
            pos.x = Mathf.RoundToInt(pos.x);
            pos.z = Mathf.RoundToInt(pos.z);
            //检查是否与现有塔穿模
            if (!CanBuild(pos))
            {
                Debug.Log("放置失败，附近已经有塔了");
                return;
            }
            if (!EconomyManager.Instance.SpendMoney(towerCost))
            {
                return;
            }
            
            Instantiate(towerPrefab, pos, Quaternion.identity);
            Debug.Log("建塔成功！" + pos);
        }
    }
    bool CanBuild(Vector3 pos)
    {
        Vector3 checkpos = new Vector3(pos.x, 0.6f, pos.z);
        Collider[] hits = Physics.OverlapSphere(checkpos, 0.6f);
        foreach(Collider hit in hits)
        {
            if(hit.GetComponent<Tower>()!= null)
            {
                return false;
            }
        }
        return true;
    }
}
