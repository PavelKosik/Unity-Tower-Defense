using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class used to create the turrets from
public class Turrets : MonoBehaviour
{   
    public float range;
    public float timeBetweenAttacks;      
    private TurretAttackEnemiesScript turretAttackEnemiesScript;
    public float damage;
    public GameObject attack;
    [HideInInspector]
    public GameObject placer;
    public float cost;
    public string turretTag;

    [HideInInspector]
    public int maxNumberOfUpdatesDamage;
    public int currentNumberOfUpdatesDamage;

    [HideInInspector]
    public int maxNumberOfUpdatesAttackSpeed;
    public int currentNumberOfUpdatesAttackSpeed;

    [HideInInspector]
    public int maxNumberOfUpdatesRange;
    public int currentNumberOfUpdatesRange;

    public TurretsUpdateStatsScript[] turretsUpdateStatsScripts;
    // Start is called before the first frame update
    void Awake()
    {
        transform.tag = turretTag;
        // we want to take the information from the TurretsUpdateStatsScript because 
        //that's where we enter the values in unity engine
        maxNumberOfUpdatesDamage = turretsUpdateStatsScripts[0].costOfUpdate.Length;
        maxNumberOfUpdatesAttackSpeed = turretsUpdateStatsScripts[1].costOfUpdate.Length;
        maxNumberOfUpdatesRange = turretsUpdateStatsScripts[2].costOfUpdate.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
