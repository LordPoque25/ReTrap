using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkins : MonoBehaviour
{

    public Sprite[] sprites;
    public SpriteRenderer charSkin;
    private CharacterManager charManager;

    void Start()
    {
        charManager = FindObjectOfType<CharacterManager>();

        if (PlayerPrefs.GetInt("skin") == 0)
        {
            for (int i = 0; i < charManager.CharactersInScene.Count; i++)
            {
                charManager.CharactersInScene[i].MyRenderer.sprite = sprites[0];
                charManager.CharactersInScene[i].Spriteon = sprites[0];
            }            
        }
        else if (PlayerPrefs.GetInt("skin") == 1)
        {
            for (int i = 0; i < charManager.CharactersInScene.Count; i++)
            {
                charManager.CharactersInScene[i].MyRenderer.sprite = sprites[1];
                charManager.CharactersInScene[i].Spriteon = sprites[1];
            }
        }
        else if (PlayerPrefs.GetInt("skin") == 2)
        {
            for (int i = 0; i < charManager.CharactersInScene.Count; i++)
            {
                charManager.CharactersInScene[i].MyRenderer.sprite = sprites[2];
                charManager.CharactersInScene[i].Spriteon = sprites[2];
            }
        }
    }
    void Update()
    {
        
    }
}
