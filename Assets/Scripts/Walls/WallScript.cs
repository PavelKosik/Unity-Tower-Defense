using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public Walls walls;
    public float currentHealth;
    public bool alive;
    public int numberOfSurroundingEnemies;
    public bool placed;  
    public float maxHealth;
    public PlaceWall placeWall;
    private BlockedPositionWallScript blockedPositionWallScript;
    public float lastSoundHealth;
    public float soundDamage;
    private WallSoundHandlerScript wallSoundHandlerScript;
    public float healthRegen;
    // Start is called before the first frame update
    void Start()
    {
        //set all the values necessary for the proper function of the wall
        walls = GetComponent<Walls>();
        currentHealth = walls.health;
        alive = true;
        placed = false;       
        maxHealth = walls.health;
        placeWall = GetComponent<PlaceWall>();
        blockedPositionWallScript = FindObjectOfType<BlockedPositionWallScript>();
        wallSoundHandlerScript = GetComponent<WallSoundHandlerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //if wall's health reaches 0 the wall gets destroyed
        if (currentHealth<=0)
        {
            alive = false;
            blockedPositionWallScript.RemovePosition(transform.position);
            gameObject.SetActive(false);
        }

        if (placeWall!=null) {

            if (placeWall.placed && walls.wallHealthImage.activeInHierarchy == false)
            {
                walls.wallHealthImageParent.SetActive(true);
            }

        }

        //scales the wall health bar to reflect the state of the wall
        if (walls.wallHealthImage.activeInHierarchy)
        {
            walls.wallHealthImage.transform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
        }

        if (placed)
        {
            //makes sure the sound is played only after certain thresholds to make sure the sound doesn't get repeated each second
            if (currentHealth!=lastSoundHealth)
            {
                lastSoundHealth = currentHealth;
                wallSoundHandlerScript.PlayTakenDamageSound();
            }

            if (healthRegen!=0)
            {
                currentHealth += healthRegen;
            }
        }
    }
}
