using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioSource grabadora;
    [SerializeField] AudioSource grabadora2;
    [SerializeField] AudioClip cancion;
    [SerializeField] AudioClip muerte;

    // Start is called before the first frame update
    void Start()
    {
        reproductorCancion();
        EnemyMovement.OnEnemyDeath += recibeEnemyDead;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproductorCancion()
    {
        grabadora.clip = cancion;
        grabadora.Play();
    }
    public void reproductorMuerte()
    {
        grabadora2.clip = muerte;
        grabadora2.Play();
    }

    public void recibeEnemyDead(EnemyMovement eneMov)
    {
        reproductorMuerte();
    }

}
