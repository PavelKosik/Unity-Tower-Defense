using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSpawnScript : MonoBehaviour
{
    public GameObject turretGameObject;
    public LayerMask enemyLayer;
    public float cost;
    private GoldManagerScript goldManagerScript;   
    private TurretPlacerScript turretPlacerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
       
        turretPlacerScript = GetComponentInParent<TurretPlacerScript>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OnInvoke()
    {
        SpawnTurret();
        yield return new WaitForEndOfFrame();
    }

    void SpawnTurret()
    {
        //turret can only be purchased if player has enough gold
        if (goldManagerScript.numberOfGold>=cost) {

            //spawns the turret
            goldManagerScript.numberOfGold -= cost;
            GameObject inst = Instantiate(turretGameObject);
            inst.transform.position = transform.parent.transform.position;            
            TurretAttackEnemiesScript turretAttackEnemiesScript = inst.AddComponent<TurretAttackEnemiesScript>();
            turretAttackEnemiesScript.enemyLayer = enemyLayer;
            inst.GetComponent<Turrets>().placer=transform.parent.gameObject;
            transform.parent.transform.SetParent(inst.transform);
            transform.parent.gameObject.SetActive(false);
            inst.tag = transform.tag;
            turretPlacerScript.buildIcon.SetActive(false);
            inst.GetComponent<Turrets>().cost = cost;
        }

        else
        {
            goldManagerScript.HandleNotEnoughGold();
        }

    }
}
