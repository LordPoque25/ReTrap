using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelKeyManager : MonoBehaviour
{
    [SerializeField] GameObject[] levelsList;

    void Start()
    {
        CheckStatus();
    }

    void Update()
    {

    }
    
    public void CheckStatus()
    {
        for (int i = 1; i < levelsList.Length; i++)

        {
            string key = "leveltag" + i;

            if (PlayerPrefs.GetInt(key) == 1)
            {
                levelsList[i].SetActive(true);
                Debug.Log("me prendi");
            }
            else if((PlayerPrefs.GetInt(key) == 0))
            {
                levelsList[i].SetActive(false);
                Debug.Log("me apague");
            }

            Debug.Log(key);
        }
       
    }
}
