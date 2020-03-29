using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    void Start()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        
    }

    public void LevelUnlock(string leveltag)
    {
        Debug.Log("has desbloqueado el nivel " + leveltag);
        PlayerPrefs.SetInt(leveltag, 1);
        PlayerPrefs.Save();
    }
}
