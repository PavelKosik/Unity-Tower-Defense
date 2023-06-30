using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackEnemiesScript : MonoBehaviour
{
    public Collider[] nearEnemies;
    public bool targetedEnemy;
    public float range;
    public LayerMask enemyLayer;
    public GameObject attack;
    public float timeBetweenAttacks;
    public GameObject baseManager;
    private Turrets turrets;
    private TurretSoundHandlerScript turretSoundHandlerScript;
    // Start is called before the first frame update
    void Start()
    {
        turretSoundHandlerScript = GetComponent<TurretSoundHandlerScript>();
        turrets = GetComponent<Turrets>(); //component used to set stats of the turret
        range = turrets.range;
        attack = turrets.attack;
        baseManager = GameObject.FindGameObjectWithTag("BaseManager");
        timeBetweenAttacks = turrets.timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenAttacks <= 0)
        {
            timeBetweenAttacks = 0;
        }

        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }



        //if we dont see an enemy we search for it
        if (targetedEnemy == false)
        {
            TargetEnemy();

            if (nearEnemies.Length > 0)
            {
                targetedEnemy = true;
            }
        }

        //else we find the enemy closest to spawn and attack it
        //the turret should always attack the enemy closes to base
        else
        {
            //each enemy has number of steps he needs to take to hit the base  
            float closestEnemyFloat = nearEnemies[0].GetComponent<EnemyBehavior>().numberToGo;
            GameObject closestEnemy = nearEnemies[0].gameObject;

            if (closestEnemy.GetComponent<EnemyBehavior>().alive)
            {
                //we start looking at index 1 because the 0 index value is default
                for (int i = 1; i < nearEnemies.Length; i++)
                {
                    if (nearEnemies[i].GetComponent<EnemyBehavior>().alive && nearEnemies[i].GetComponent<EnemyBehavior>().numberToGo < closestEnemyFloat)
                    {
                        closestEnemyFloat = nearEnemies[i].GetComponent<EnemyBehavior>().numberToGo;
                        closestEnemy = nearEnemies[i].gameObject;

                    }
                }
            }

            //handles what should happen in the first selected enemy is not alive 
            else
            {
                for (int i = 1; i < nearEnemies.Length; i++)
                {
                    if (nearEnemies[i].GetComponent<EnemyBehavior>().alive)
                    {
                        closestEnemyFloat = nearEnemies[i].GetComponent<EnemyBehavior>().numberToGo;
                        closestEnemy = nearEnemies[i].gameObject;
                        break;
                    }
                }

                for (int i = 1; i < nearEnemies.Length; i++)
                {
                    if (nearEnemies[i].GetComponent<EnemyBehavior>().alive && nearEnemies[i].GetComponent<EnemyBehavior>().numberToGo < closestEnemyFloat)
                    {
                        closestEnemyFloat = nearEnemies[i].GetComponent<EnemyBehavior>().numberToGo;
                        closestEnemy = nearEnemies[i].gameObject;

                    }
                }
            }

            if (closestEnemy.GetComponent<EnemyBehavior>().alive == false)
            {
                closestEnemy = null;
                targetedEnemy = false;
            }


            if (closestEnemy != null)
            {
                StartCoroutine(AttackEnemy(closestEnemy));
            }
        }

    }

    void TargetEnemy()
    {
        range = turrets.range;
        nearEnemies = Physics.OverlapSphere(transform.position, range, enemyLayer);
    }

    IEnumerator AttackEnemy(GameObject _enemyToAttack)
    {

        if (timeBetweenAttacks <= 0)
        {
            turretSoundHandlerScript.PlayProjectileSound();
            timeBetweenAttacks = turrets.timeBetweenAttacks;
            yield return new WaitForSeconds(0.2f); //wait for sound
            GameObject _attack = Instantiate(attack);
            _attack.transform.SetParent(transform);
            _attack.transform.position = transform.position;
            _attack.AddComponent<BoxCollider>();
            _attack.GetComponent<BoxCollider>().isTrigger = true;
            _attack.tag = "Attack";
            Rigidbody _rb = _attack.AddComponent<Rigidbody>();
            _rb.useGravity = false;
            TurretProjectileScript turretProjectileScript = _attack.AddComponent<TurretProjectileScript>();
            turretProjectileScript.enemyToAttack = _enemyToAttack;
            turretProjectileScript.turretTag = transform.tag;
        }


        if (_enemyToAttack.activeInHierarchy == false || StaticClass.IsInRange(transform, _enemyToAttack, range) == false || _enemyToAttack.GetComponent<EnemyBehavior>().alive == false)
        {
            targetedEnemy = false;
        }

    }



}
