using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
            resetStore();
        }
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("leveltag1", 0);
        PlayerPrefs.SetInt("leveltag2", 0);
        PlayerPrefs.SetInt("leveltag3", 0);
        PlayerPrefs.Save();
    }

    public void resetStore()
    {
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("skins", 0);
    }
}
