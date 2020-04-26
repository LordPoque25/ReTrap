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
        SceneManager.LoadScene(sceneName);
    }
    public void Victory()
    {
        Debug.Log("Jaja ganates xd");
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
