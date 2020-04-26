using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Atributos
    private string sceneName;
    [SerializeField] private List<EnemyMovement> enemiesInScene = new List<EnemyMovement>();
    private CharacterManager characterManagerInScene;

    // Accesores
    public CharacterManager CharacterManagerInScene { get => characterManagerInScene; set => characterManagerInScene = value; }
    public List<EnemyMovement> EnemiesInScene { get => enemiesInScene; set => enemiesInScene = value; }

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        characterManagerInScene = FindObjectOfType<CharacterManager>();
        EnemyMovement.OnFinalCollider += Defeat;
        CharacterMovement.OnStateTrap += ActivateComprobationTrap;
        Trap.OnEnemyKill += ComprobateActiveEnemies;
    }
    void Update()
    {
        
    }
    public void Defeat()
    {
        SceneManager.LoadScene("OpenMenuScene");
    }
    public void Victory()
    {
        int indexscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexscene + 1);
    } 
    public void ComprobateActiveEnemies()
    {
        if (EnemiesInScene.Count < 1)
        {
            Victory();
        }
        else
        {
            Debug.Log("Faltan Enemigos Por Asesinar");
        }
    }
    public void ActivateComprobationTrap()
    {
        StartCoroutine(ComprobateAfterTrap());
    }
    IEnumerator ComprobateAfterTrap()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("Todavía hay" + CharacterManagerInScene.CharactersInScene.Count + "Characters en esta escena");
        if (CharacterManagerInScene.CharactersInScene.Count <= 0)
        {
            Debug.Log("Ostras, te has quedao sin characters");
            yield return new WaitForSeconds(0.09f);
            Debug.Log("Hay todavía" + EnemiesInScene.Count + "En la Escena");
            if (EnemiesInScene.Count > 0)
            {
                Defeat();
            }
        }
        if (EnemiesInScene.Count < 1)
        {
            Victory();
        }
    }
}
