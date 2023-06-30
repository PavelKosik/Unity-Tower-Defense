using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{

    private Rigidbody rb;
    private BaseScript baseScript;
    public float health;
    public float maxHealth;
    public int rewardForKilling;
    public float speed;
    private GoldManagerScript goldManagerScript;
    public bool alive;
    public float numberToGo;
    public int damageToBase;
    public float damageToWall;
    public float timeToAttackWall;
    public PathFollower pathFollower;
    public EnemyAttackWallsScript enemyAttackWallsScript;
    public GameObject healthImage;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        baseScript = FindObjectOfType<BaseScript>();
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
        alive = true;

        pathFollower = GetComponent<PathFollower>();
        numberToGo = pathFollower.pathCreator.path.length;

        enemyAttackWallsScript = GetComponent<EnemyAttackWallsScript>();
        maxHealth = health;


    }

    // Update is called once per frame
    void Update()
    {
        //numberToGo is used only for turrets to detect the enemy closest to base
        //enemies follow the same path with the same speed so we just decrease the number by deltaTime
        numberToGo -= Time.deltaTime;

        CheckIfAlive();

        healthImage.transform.localScale = new Vector3(health / maxHealth, 1, 1);


        if (alive == false)
        {
            healthImage.SetActive(false);
        }

        //if enemy was attacking the wall but the wall is not there anymore
        if (pathFollower.attacking)
        {
            if (enemyAttackWallsScript.wallToAttack.GetComponent<WallScript>().alive == false)
            {
                pathFollower.attacking = false;
                enemyAttackWallsScript.wallToAttack = null;
            }
        }
    }

    //if enemy reaches the end of the path he damages the players base
    void DamageBase(int damage)
    {
        baseScript.health -= damage;
        gameObject.SetActive(false);
    }



    private void OnTriggerEnter(Collider collider)
    {
        //if enemy collides with turret attack he takes damage
        if (collider.tag == "Attack")
        {
            collider.gameObject.SetActive(false);
            health -= collider.GetComponentInParent<Turrets>().damage;
        }

        //if he collides with the base he damages it
        if (collider.tag == "BaseManager")
        {
            DamageBase(damageToBase);
        }
            
        //if he collides with the wall he checks if the wall is in front of him
        //if the wall is in front of him he starts attacking it
        if (collider.tag == "Wall" && collider.GetComponent<PlaceWall>().placed)
        {
            if (IsWallInFrontOf())
            {
                enemyAttackWallsScript.wallToAttack = collider.gameObject;
                Attack();

            }
        }


    }

    private void OnTriggerStay(Collider collider)
    {
        //he continues to attack the wall until it's destroyed
        if (collider.tag == "Wall" && collider.GetComponent<PlaceWall>().placed)
        {
            if (IsWallInFrontOf())
            {
                Attack();

            }
        }
    }

    void CheckIfAlive()
    {
        //if enemy's health reaches 0 he is killed and player is rewarded
        if (health <= 0 && alive)
        {
            alive = false;
            StartCoroutine(GetComponent<Enemies>().Die());
            goldManagerScript.numberOfGold += rewardForKilling;


        }
    }


    void Attack()
    {
        //attacks the wall
        pathFollower.attacking = true;
        enemyAttackWallsScript.Attack(damageToWall, timeToAttackWall);
    }

    bool IsWallInFrontOf()
    {
        //checks if there is a wall in the direction the enemy is facing
        bool isWallInFrontOf = false;
        Ray ray = new Ray(transform.position + (transform.up / 5), transform.up);

        if (Physics.Raycast(ray, 10))
        {
            isWallInFrontOf = true;
        }

        return isWallInFrontOf;
    }
}


