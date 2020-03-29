using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    Transform enemytransform;
    [SerializeField] float newpositionxenemy;
    [SerializeField] float newpositionyenemy;
    private bool wallcollition;
    private bool canMove = false;
    Vector3 LastPosition;

    // Eventos
    public delegate void onCondition();
    public static event onCondition OnFinalCollider;

    void Start()
    {
        enemytransform = GetComponent<Transform>();
        LastPosition = transform.position;
        wallcollition = false;
        CharacterMovement.OnMouseOverCharacter += AllowMeToMove;
        CharacterMovement.OnStateTrap += mirrormovementynegative;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.W) && wallcollition == false)
            {
                LastPosition = gameObject.transform.position;
                mirrormovementynegative();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                LastPosition = gameObject.transform.position;
                mirrormovementxnegative();
            }


            if (Input.GetKeyDown(KeyCode.D))
            {
                LastPosition = gameObject.transform.position;
                mirrormovementx();
            }

            if (wallcollition == true)
            {
                gameObject.transform.position = LastPosition;
            }
        }     
    }

    public void mirrormovementx()
    {
        enemytransform.position += new Vector3(newpositionxenemy, -0.86f, 0);
    }

    public void mirrormovementxnegative()
    {
        enemytransform.position += new Vector3(newpositionxenemy * -1, -0.86f, 0);
    }

    public void mirrormovementynegative()
    {
        enemytransform.position += new Vector3(0, newpositionyenemy * -1, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallcollition = true;            
        }
        if (collision.gameObject.tag == "Final")
        {
            OnFinalCollider();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            wallcollition = false;            
        }
    }
    public void AllowMeToMove()
    {
        canMove = true;
    }
}
