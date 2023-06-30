using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used as a default class for each type of enemy
public class Enemies : MonoBehaviour
{
    public int damageToBase;
    public float health;
    public float speed;
    public int rewardForKilling;
    public float timeToAttackWall;
    public float damageToWall;
    public GameObject healthImage;
    public TextMesh goldText;
    public float timeOfAnimation;
    private EnemySoundHandlerScript enemySoundHandlerScript;
    // Start is called before the first frame update
    void Start()
    {
        enemySoundHandlerScript = GetComponent<EnemySoundHandlerScript>();
            
        goldText.text = "+" + rewardForKilling;
        goldText.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Die()
    {
        //handles enemy death
        enemySoundHandlerScript.PlayGoldSound();
        healthImage.transform.parent.gameObject.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.3f);                     
        goldText.transform.parent.gameObject.SetActive(true);        
        yield return new WaitForSeconds(1);
        goldText.transform.parent.gameObject.SetActive(false);
        GetComponentInParent<EnemyBehavior>().gameObject.SetActive(false);
    }
}
