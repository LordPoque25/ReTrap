using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Atributos
    private string sceneName;
    [SerializeField] private List<EnemyMovement> enemiesInScene = new List<EnemyMovement>();
    private CharacterManager characterManagerInScene;
    public int RawLevel = 0;
    public bool finalLevel = false;
    public int money;

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
        money = PlayerPrefs.GetInt("money");

        if (!PlayerPrefs.HasKey("leveltag" + RawLevel))
        {
            PlayerPrefs.SetInt("leveltag" + RawLevel, 0);
        }        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Victory();
        }        
    }
    public void Defeat()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Victory()
    {
        money += 100;
        RawLevel += 1;
        string levelTag = "leveltag" + RawLevel;
        LevelManager.instance.LevelUnlock(levelTag);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
        if (finalLevel == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("Levels");
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
            Debug.Log("Faltan Enemigos Por Asesinar");
        }
    }
    public void ActivateComprobationTrap()
    {
        StartCoroutine(ComprobateAfterTrap());
    }
    IEnumerator ComprobateAfterTrap()
    {
        Debug.Log(CharacterManagerInScene.CharactersInScene.Count);
        if (CharacterManagerInScene.CharactersInScene.Count <= 0)
        {
            Debug.Log("Ostras, te has quedao sin characters");
            yield return new WaitForSeconds(0.2f);
            if (EnemiesInScene.Count < 1)
            {
                Victory();
            }
            else
            {
                Defeat();
            }
        }
    }

}
