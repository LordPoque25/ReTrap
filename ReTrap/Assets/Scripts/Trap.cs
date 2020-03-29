using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    GameManager gamemanager;
    public delegate void OnKill();
    public static event OnKill OnEnemyKill;
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {            
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gamemanager.EnemiesInScene.Remove(collision.GetComponent<EnemyMovement>());
            OnEnemyKill();
        }
        
    }


}
