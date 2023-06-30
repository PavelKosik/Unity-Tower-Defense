using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManagerScript : MonoBehaviour
{
    public List<GameObject> enemyAlive = new List<GameObject>();
    public EnemiesSpawnerComponent[] enemiesSpawnerComponents;
    public GameObject victoryScreen;
    public GameObject defeatScreen;
    private BaseScript baseScript;
    // Start is called before the first frame update
    void Start()
    {
        //gets all the necessary references
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
        //player wins if the kills all the enemies of every wave
        for (int i = 0; i < enemyAlive.Count; i++)
        {
            if (enemyAlive[i].activeInHierarchy == false)
            {
                enemyAlive.RemoveAt(i);
            }
        }

        if (enemyAlive.Count <= 0)
        {
            for (int i = 0; i < enemiesSpawnerComponents.Length; i++)
            {

                if (enemiesSpawnerComponents[i].lastWaveSpawned == false)
                {
                    return;
                }

            }
            victoryScreen.SetActive(true);

        }
    }

    void CheckIfLost()
    {
        //player loses if health of his base reaches 0
        if (baseScript.health <= 0)
        {
            defeatScreen.SetActive(true);
        }
    }
}
