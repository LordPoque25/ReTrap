using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public int actualMoney;
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
        PlayerPrefs.SetInt("skin", Item);
        Debug.Log("compre la skin " + Item);
        PlayerPrefs.Save();
        Debug.Log("e comprado una skin");
    }

}
