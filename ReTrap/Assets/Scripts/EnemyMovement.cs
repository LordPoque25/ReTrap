﻿using System.Collections;
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
    Vector3 actualPosition;
    [SerializeField] ParticleSystem blood;

    // Eventos
    public delegate void onCondition();
    public static event onCondition OnFinalCollider;
    public static event onCondition OnAllyCollision;
    public delegate void onDeath(EnemyMovement myself);
    public static event onDeath OnEnemyDeath;

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


        actualPosition = transform.position;

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
                mirrormovementynegative();
            }


            if (Input.GetKeyDown(KeyCode.D))
            {
                LastPosition = gameObject.transform.position;
                mirrormovementx();
                mirrormovementynegative();
            }

            if (wallcollition == true)
            {
                gameObject.transform.position = LastPosition;
            }
        }     
    }

    private void OnDestroy()
    {
        blood.transform.position = actualPosition;
        blood.Play();
        OnEnemyDeath(this);
    }

    public void mirrormovementx()
    {
        enemytransform.position += new Vector3(newpositionxenemy,0, 0);
    }

    public void mirrormovementxnegative()
    {
        enemytransform.position += new Vector3(newpositionxenemy * -1,0, 0);
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
        if (collision.gameObject.tag == "Ally")
        {
            OnAllyCollision();
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
