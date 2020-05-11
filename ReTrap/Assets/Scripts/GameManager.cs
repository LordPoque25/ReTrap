using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    // Atributos
    private string sceneName;
    private List<EnemyMovement> enemiesInScene = new List<EnemyMovement>();
    private List<CharacterMovement> charactersInScene = new List<CharacterMovement>();
    private bool VictoryBug = false;

    // Accesores
    public List<EnemyMovement> EnemiesInScene { get => enemiesInScene; set => enemiesInScene = value; }
    public List<CharacterMovement> CharactersInScene { get => charactersInScene; set => charactersInScene = value; }

    // Singleton
    public static GameManager instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            
        haventwonorlostyet();
        sceneName = SceneManager.GetActiveScene().name;
        EnemyMovement.OnFinalCollider += Defeat;
        EnemyMovement.OnAllyCollision += ComprobateActiveEnemies;
        EnemyMovement.OnEnemyDeath += RemoveFromList;
        CharacterMovement.OnMyDeath += RemoveFromList;
        CharacterMovement.OnStateTrap += ActivateComprobationTrap;
        CharacterMovement.OnMySelection += SelectOneCharacter;
        Trap.OnEnemyKill += ComprobateActiveEnemies;
        LookForEnemiesAndAllies();
        StartCoroutine(PrimeraActivacion());
    }
    void Start()
    {

    }
    public void LookForEnemiesAndAllies()
    {
        EnemiesInScene = Object.FindObjectsOfType<EnemyMovement>().ToList();
        CharactersInScene = Object.FindObjectsOfType<CharacterMovement>().ToList();
    }
    public void RemoveFromList(CharacterMovement _CharToRemove)
    {
        CharactersInScene.Remove(_CharToRemove);
        ActivateComprobationTrap();
    }
    public void RemoveFromList(EnemyMovement _EnemyToRemove)
    {
        EnemiesInScene.Remove(_EnemyToRemove);
        ComprobateActiveEnemies();
    }
    public void Defeat()
    {
        if (VictoryBug==false)
        {
            StartCoroutine(SceneAfterGameplay(2));
            VictoryBug = true;
        }

    }
    public void Victory()
    {
        if (VictoryBug==false)
        {
            StartCoroutine(SceneAfterGameplay(1));
            VictoryBug = true;
        }

    } 
    public void ComprobateActiveEnemies()
    {
        if (EnemiesInScene.Count < 1)
        {
            Victory();
        }
        else
        {
            Debug.Log("Faltan "+enemiesInScene.Count +" Enemigos Por Asesinar");
        }
    }
    public void ActivateComprobationTrap()
    {
        StartCoroutine(ComprobateAfterTrap());
    }
    IEnumerator ComprobateAfterTrap()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("Todavía hay" + CharactersInScene.Count + " Characters en esta escena");
        if (CharactersInScene.Count <= 0)
        {
            Debug.Log("Ostras, te has quedao sin characters");
            yield return new WaitForSeconds(0.09f);
            Debug.Log("Hay todavía " + EnemiesInScene.Count + " Enemigos En la Escena");
            if (EnemiesInScene.Count > 0)
            {
                Defeat();
            }
        }
        else
        {
            if (EnemiesInScene.Count < 1)
            {
                Victory();
            }
        }
    }
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
    IEnumerator SceneAfterGameplay(int _1forwin2forlose)
    {
        yield return new WaitForSeconds(1);
        if (_1forwin2forlose == 1)
        {
            SceneManager.LoadScene("Ganaste");
        }
        if (_1forwin2forlose == 2)
        {
            SceneManager.LoadScene("Perdiste");
        }
    }
    public void haventwonorlostyet()
    {
        VictoryBug = false;
    }
}
