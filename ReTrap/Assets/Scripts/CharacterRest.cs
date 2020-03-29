using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRest : MonoBehaviour
{
    [SerializeField] GameObject character;
    Vector3 posicionactual;
    

    void Start()
    {
        posicionactual = gameObject.transform.position;
    }
   
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
           gameObject.transform.position = posicionactual;
           CharacterRestSpawn();
           character.SetActive(true);
           gameObject.SetActive(false);
        }
    }

    public void CharacterRestSpawn()
    {        
        GameObject characterclone = Instantiate(character);
        Instantiate(characterclone, posicionactual, Quaternion.identity);        
    }

   
}
