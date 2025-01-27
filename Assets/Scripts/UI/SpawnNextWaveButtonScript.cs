﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextWaveButtonScript : MonoBehaviour
{
    public EnemiesSpawnerComponent[] enemySpawners;
    // Start is called before the first frame update
    void Start()
    {
        //gets all the places enemies can spawn at in the given level
        GameObject[] enemySpawnersGameObject = GameObject.FindGameObjectsWithTag("Path");
        enemySpawners = new EnemiesSpawnerComponent[enemySpawnersGameObject.Length];
     
        for (int i=0; i< enemySpawnersGameObject.Length; i++)
        {
            enemySpawners[i] = enemySpawnersGameObject[i].GetComponent<EnemiesSpawnerComponent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //spawns the waves
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            enemySpawners[i].shouldSpawn = true;
        }
    }
}
