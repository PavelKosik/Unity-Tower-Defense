using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManagerScript : MonoBehaviour
{
    public List<GameObject> enemyAlive = new List<GameObject>();
   // public bool allWavesSpawned;
    public EnemiesSpawnerComponent[] enemiesSpawnerComponents;
    public GameObject victoryScreen;
    public GameObject defeatScreen;
    private BaseScript baseScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemySpawnersGameObject = GameObject.FindGameObjectsWithTag("Path");
        enemiesSpawnerComponents = new EnemiesSpawnerComponent[enemySpawnersGameObject.Length];

        for (int i = 0; i < enemySpawnersGameObject.Length; i++)
        {
            enemiesSpawnerComponents[i] = enemySpawnersGameObject[i].GetComponent<EnemiesSpawnerComponent>();
        }

        baseScript = FindObjectOfType<BaseScript>();
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfWon();
        CheckIfLost();
    }

    void CheckIfWon()
    {

        for (int i = 0; i < enemyAlive.Count; i++)
        {
            if (enemyAlive[i].activeInHierarchy == false)
            {
                enemyAlive.RemoveAt(i);
            }
        }

        if (enemyAlive.Count <= 0)
        {
            for (int i = 0; i < enemiesSpawnerComponents.Length; i++) {

                if (enemiesSpawnerComponents[i].lastWaveSpawned==false) {
                    return;
                }

            }
            Debug.Log("Win");
            victoryScreen.SetActive(true);

        }
    }

    void CheckIfLost()
    {
        if (baseScript.health <= 0)
        {
            Debug.Log("Lost");
            defeatScreen.SetActive(true);
        }
    }
}
