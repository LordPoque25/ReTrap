using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Atributos
    Transform MovementTransform;
    [SerializeField] float newpositionx;
    [SerializeField] float newpositiony;
    [SerializeField] GameObject trap;
    [SerializeField] Sprite spriteon;
    [SerializeField] Sprite spriteoff;
    private SpriteRenderer myRenderer;
    private bool wallcollitionplayer;
    Vector3 lastpositionplayer;
    private bool selected;

    // Eventos
    public delegate void onMouseOver();
    public static event onMouseOver OnMouseOverCharacter;
    public delegate void onStateChange();
    public static event onStateChange OnStateTrap;
    public delegate void onmyself(CharacterMovement Myself);
    public static event onmyself OnMyDeath;
    public static event onmyself OnMySelection;

    // Accesores
    public bool Selected { get => selected; set => selected = value; }
    public SpriteRenderer MyRenderer { get => myRenderer; set => myRenderer = value; }
    public Sprite Spriteon { get => spriteon; set => spriteon = value; }
    public Sprite Spriteoff { get => spriteoff; set => spriteoff = value; }

    void Start()
    {
        MovementTransform = GetComponent<Transform>();
        MyRenderer = GetComponent<SpriteRenderer>();
        wallcollitionplayer = false;
        Selected = false;
        lastpositionplayer = transform.position;
    }
    
    void Update()   {

        if (Selected)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                lastpositionplayer = gameObject.transform.position;
                MoveY();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                lastpositionplayer = gameObject.transform.position;
                MoveNegativeX();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                lastpositionplayer = gameObject.transform.position;
                MoveX();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                trapspawn();
            }

            if (wallcollitionplayer == true)
            {
                gameObject.transform.position = lastpositionplayer;
            }

        }

        /*if (Input.GetMouseButtonDown(0))
        {
            lastpositionplayer = gameObject.transform.position;
            CharacterSpawn();
            characterest.SetActive(true);
            gameObject.SetActive(false);
        }*/
    }

    public void MoveX()
    {
        MovementTransform.position += new Vector3(newpositionx, 0, 0);
    }

    public void MoveNegativeX()
    {
        MovementTransform.position += new Vector3(newpositionx*-1, 0, 0);
    }

    public void MoveY()
    {
        MovementTransform.position += new Vector3(0, newpositiony, 0);
    }

    public void trapspawn()
    {
        GameObject trapclone = Instantiate(trap);        
        trapclone.transform.position = MovementTransform.position;
        OnMyDeath(this);
        gameObject.SetActive(false);
        OnStateTrap();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallcollitionplayer = true;            
        }
        if (collision.gameObject.tag == "FinalCharCollider")
        {
            OnMyDeath(this);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            wallcollitionplayer = false;
        }
    }

    private void OnMouseDown()
    {
        OnMySelection(this);
        OnMouseOverCharacter();
    }
    private void OnDestroy()
    {
        OnMyDeath(this);
    }
    public void callevent1()
    {
        OnMouseOverCharacter();
    }

}
