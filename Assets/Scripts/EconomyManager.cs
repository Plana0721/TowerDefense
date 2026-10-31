using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;
    public int money = 100; //初始金钱
    public TextMeshProUGUI moneyText; 
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
        Debug.Log("获得金币:"+amount+",当前："+money);
    }
    public bool SpendMoney(int amount)
    {
        if (money < amount)
        {
            Debug.Log("金币不足！");
            return false;
        }
        money -= amount;
        UpdateUI();
        return true;
    }
    // Update is called once per frame
    void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "Gold:"+money;
        }
    }
}
