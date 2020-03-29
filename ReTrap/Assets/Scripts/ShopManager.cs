using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public int actualMoney;
    public int price = 100;
    public Text moneyUI;

    void Start()
    {
        if (!PlayerPrefs.HasKey("skin"))
        {
            PlayerPrefs.SetInt("skin", 0);
        }
        actualMoney = PlayerPrefs.GetInt("money");
    }

    void Update()
    {
        moneyUI.text = actualMoney.ToString();
    }

    public void Buy(int Item)
    {        
        if (price <= actualMoney)
        {
            PlayerPrefs.SetInt("skin", Item);
            actualMoney -= price;
            PlayerPrefs.SetInt("money", actualMoney);
            PlayerPrefs.Save();
        }
    }

}
