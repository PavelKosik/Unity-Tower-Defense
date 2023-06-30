using JetBrains.Annotations;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackWallsScript : MonoBehaviour
{
    private float currentAttackTime;

    [HideInInspector]
    public GameObject wallToAttack;

    private PathFollower pathFollower;

    [HideInInspector]
    public float arrived;
    // Start is called before the first frame update
    void Start()
    {
        pathFollower = GetComponent<PathFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(float damage, float timeToAttack)
    {
        if (wallToAttack!=null) {

            WallScript wallScript = wallToAttack.GetComponent<WallScript>();

            Ray ray = new Ray(transform.position, wallToAttack.transform.position - transform.position);
            Quaternion lookRotation = Quaternion.LookRotation(transform.forward, ray.direction);
            transform.rotation = lookRotation;
            //walls take damage after a certain interval
            if (currentAttackTime >= timeToAttack)
            {
                wallScript.currentHealth -= damage;
                currentAttackTime = 0f;
            }

            else
            {
                currentAttackTime += Time.deltaTime;
            }

            //checks the number of surronding enemies
            //this makes sure that enemies leave the wall in queue based on who arrived first and not all of them at the same time
            if (arrived == 0)
            {
                wallScript.numberOfSurroundingEnemies++;
                arrived = wallScript.numberOfSurroundingEnemies;
            }
        }
        //once the wall has been destroyed the enemy continues to walk towards the base
        else
        {
            pathFollower.attacking = false;
        }
    }

    
}
