using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//used to spawn enemies 
public class EnemiesSpawnerComponent : MonoBehaviour
{
    public GameObject orcEnemyPrefab;
    //public int numberOfWaves;   
    private PathCreator pathCreator;   
    public float timeBetweenSpawn;
    public bool lastWaveSpawned = false;
    private int numberOfSpawnedWaves;   
    public WaveScript[] waveScripts;
    public bool shouldSpawn=false; 
    private WinLoseManagerScript winLoseManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        
        pathCreator = GetComponent<PathCreator>();
        
        winLoseManagerScript = GameObject.FindObjectOfType<WinLoseManagerScript>();
        numberOfSpawnedWaves = 0;     
        StartCoroutine(MakeEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSpawn)
        {
            StartCoroutine(MakeEnemy());
        }
    }
    IEnumerator MakeEnemy()
    {
        if (shouldSpawn) {
            shouldSpawn = false;
            while (numberOfSpawnedWaves < waveScripts.Length)
            {
                for (int i = 0; i < waveScripts[numberOfSpawnedWaves].orcNumber; i++)
                {
                    GameObject inst = Instantiate(orcEnemyPrefab);
                    winLoseManagerScript.enemyAlive.Add(inst);
     
                    inst.AddComponent<Rigidbody>();

                    //assign all the values for out enemy
                    EnemyBehavior enemyBehavior = inst.AddComponent<EnemyBehavior>();
                    enemyBehavior.health = orcEnemyPrefab.GetComponent<Enemies>().health;
                    enemyBehavior.rewardForKilling = orcEnemyPrefab.GetComponent<Enemies>().rewardForKilling;
                    enemyBehavior.speed = orcEnemyPrefab.GetComponent<Enemies>().speed;
                    enemyBehavior.damageToBase = orcEnemyPrefab.GetComponent<Enemies>().damageToBase;
                    enemyBehavior.damageToWall = orcEnemyPrefab.GetComponent<Enemies>().damageToWall;
                    enemyBehavior.timeToAttackWall = orcEnemyPrefab.GetComponent<Enemies>().timeToAttackWall;
                    enemyBehavior.healthImage = inst.GetComponent<Enemies>().healthImage;


                    BoxCollider box = inst.AddComponent<BoxCollider>();
                    box.isTrigger = true;

                    //assign all values needed for PathFollower component
                    PathFollower pathFollower = inst.AddComponent<PathFollower>();
                    pathFollower.pathCreator = pathCreator;
                    pathFollower.speed = enemyBehavior.speed;
                    pathFollower.endOfPathInstruction = EndOfPathInstruction.Stop;
                    yield return new WaitForSeconds(timeBetweenSpawn);
                }

                numberOfSpawnedWaves += 1;
                break;
            }

            if (numberOfSpawnedWaves==waveScripts.Length)
            {
                lastWaveSpawned = true;
            }

        }

        else
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
}
