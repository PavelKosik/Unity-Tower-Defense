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

        healthImage.transform.localScale = new Vector3(health/maxHealth, 1, 1);
        

        if(alive==false)
        {
            healthImage.SetActive(false);
        }


        if (pathFollower.attacking)
        {
            if (enemyAttackWallsScript.wallToAttack.GetComponent<WallScript>().alive==false)
            {
                pathFollower.attacking = false;
                enemyAttackWallsScript.wallToAttack = null;
            }
        }     
    }

   
    void DamageBase(int damage)
    {
        baseScript.health -= damage;
        gameObject.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider collider)
    {
      
       
        if (collider.tag == "Attack")
        {
            collider.gameObject.SetActive(false);
            health -= collider.GetComponentInParent<Turrets>().damage;
        }

        if (collider.tag=="BaseManager")
        {
            DamageBase(damageToBase);
        }

        
            if (collider.tag == "Wall" && collider.GetComponent<PlaceWall>().placed)
            {
                Debug.Log("aa");

                if (IsWallInFrontOf()) {

                    enemyAttackWallsScript.wallToAttack = collider.gameObject;
                    Attack();

                }
            }
        

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Wall" && collider.GetComponent<PlaceWall>().placed)
        {                      

            if (IsWallInFrontOf())
            {

                //enemyAttackWallsScript.wallToAttack = collider.gameObject;
                Attack();

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      

        if (IsWallInFrontOf())
        {
            if (collision.collider.tag == "Wall" && collision.collider.GetComponent<PlaceWall>().placed)
            {
                Debug.Log("aa");
                enemyAttackWallsScript.wallToAttack = collision.gameObject;
                Attack();
            }
        }
    }
        

    
    void CheckIfAlive()
    {
       
        if (health <= 0 && alive)
        {
            //gameObject.SetActive(false);
            alive = false;
            StartCoroutine(GetComponent<Enemies>().Die());
            goldManagerScript.numberOfGold += rewardForKilling;
           
          
        }
    }


    void Attack()
    {
        pathFollower.attacking = true;
        enemyAttackWallsScript.Attack(damageToWall, timeToAttackWall);
       
    }
    
    bool IsWallInFrontOf()
    {
        bool isWallInFrontOf = false; 
        Debug.DrawRay(transform.position+transform.up, transform.up);
        Ray ray = new Ray(transform.position+(transform.up/5), transform.up);

        if (Physics.Raycast(ray, 10))
        {
            isWallInFrontOf = true;
            //Debug.Log("yes");
        }

        return isWallInFrontOf;
    }
}


