using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkins : MonoBehaviour
{

    public Sprite[] sprites;
    SpriteRenderer MyCharRenderer;
    CharacterMovement MyCharacter;

    void Start()
    {
        MyCharRenderer = GetComponent<SpriteRenderer>();
        MyCharacter = GetComponent<CharacterMovement>();
        Debug.Log("mi skin es " + PlayerPrefs.GetInt("skin"));

        if (PlayerPrefs.GetInt("skin") == 0)
        {
            for (int i = 0; i < GameManager.instance.CharactersInScene.Count; i++)
            {
                MyCharacter.Spriteoff = sprites[3];
                MyCharRenderer.sprite = sprites[0];
                MyCharacter.Spriteon = sprites[0];
            }            
        }
        else if (PlayerPrefs.GetInt("skin") == 1)
        {
            for (int i = 0; i < GameManager.instance.CharactersInScene.Count; i++)
            {
                MyCharacter.Spriteoff = sprites[4];
                MyCharRenderer.sprite = sprites[1];
                MyCharacter.Spriteon = sprites[1];
            }
        }
        else if (PlayerPrefs.GetInt("skin") == 2)
        {
            for (int i = 0; i < GameManager.instance.CharactersInScene.Count; i++)
            {
                MyCharacter.Spriteoff = sprites[5];
                MyCharRenderer.sprite = sprites[2];
                MyCharacter.Spriteon = sprites[2];
            }
        }
    }
    
}
