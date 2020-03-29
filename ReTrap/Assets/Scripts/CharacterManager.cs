using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Atributos
    [SerializeField]private List<CharacterMovement> charactersInScene = new List<CharacterMovement>();

    //Accesores
    public List<CharacterMovement> CharactersInScene { get => charactersInScene; set => charactersInScene = value; }

    private void Start()
    {
        StartCoroutine(PrimeraActivacion());        
    }

    // Métodos
    public void SelectOneCharacter(CharacterMovement _character)
    {
        for (int i = 0; i < CharactersInScene.Count; i++)
        {
            CharactersInScene[i].Selected = false;
            CharactersInScene[i].MyRenderer.sprite = CharactersInScene[i].Spriteoff;
        }
        for (int l = 0; l < CharactersInScene.Count; l++)
        {
            if (_character == CharactersInScene[l])
            {
                CharactersInScene[l].Selected = true;
                CharactersInScene[l].MyRenderer.sprite = CharactersInScene[l].Spriteon;
                CharactersInScene[l].callevent1();
                break;
            }
        }
    }
    IEnumerator PrimeraActivacion()
    {
        yield return new WaitForSeconds(0.3f);
        SelectOneCharacter(CharactersInScene[0]);
    }
}
