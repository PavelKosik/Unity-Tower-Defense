using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairWallScript : MonoBehaviour
{
    private WallScript wallScript;
    private Walls walls;
    private GoldManagerScript goldManagerScript;
    private float repairCost;
    public TextMesh priceText;
    private float damageTaken;
    private float healthNeededToRepair;
    // Start is called before the first frame update
    void Start()
    {
        wallScript = GetComponentInParent<WallScript>();
        walls = GetComponentInParent<Walls>();
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculates repair cost based on the damage the wall has taken
        damageTaken = wallScript.currentHealth / wallScript.maxHealth * 100;
        healthNeededToRepair = 100 - damageTaken;
        repairCost = Mathf.RoundToInt(walls.cost * healthNeededToRepair / 100);
        priceText.text = "Price: "+repairCost.ToString();
    }

    public IEnumerator OnInvoke()
    {
        //in case the wall would take damage but not enough of it to make a repairCost round to 1
        if (healthNeededToRepair>0 && repairCost==0)
        {
            repairCost = 1;
        }
        //if player has enough gold to repair -> repair the wall
        if (goldManagerScript.numberOfGold>=repairCost)
        {
            goldManagerScript.numberOfGold -= repairCost;
            wallScript.currentHealth = wallScript.maxHealth;
        }
        //else notify the player that he hasn't got enough gold
        else
        {
            goldManagerScript.HandleNotEnoughGold();
        }

        yield return new WaitForEndOfFrame();
    }
 }
