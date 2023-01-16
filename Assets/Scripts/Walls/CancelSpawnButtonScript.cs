using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelSpawnButtonScript : MonoBehaviour
{
    public SpawnButtonScript spawnButtonScript;
    public GoldManagerScript goldManagerScript;
    public Image wallImage;
    // Start is called before the first frame update
    void Start()
    {
        spawnButtonScript = GetComponentInParent<SpawnButtonScript>();
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the user left clicks on the cancel spawn image it cancels the spawn
        if (Input.GetMouseButtonDown(1)&&spawnButtonScript.spawning)
        {
            CancelSpawn();
        }
    }

    public void CancelSpawn()
    {   // deactive the turret that follows mouse cursor 
        // because it shouldn't be there after user cancels the spawning
        spawnButtonScript.spawnedGameObject.SetActive(false);
        
        // this line was there to make sure the CancelSpawn doesn't disable already spawned turret but
        // it's not necessery anymore
        //spawnButtonScript.spawnedGameObject = null; 

        // set spawning to false so player can spawn another wall in SpawnButtonScript
        spawnButtonScript.spawning = false;

        // return the cost of the wall back to the player
        goldManagerScript.numberOfGold += spawnButtonScript.costOfTheWall;

        // disable this gameObject so the cancel image doesn't block the spawn image
        gameObject.SetActive(false);

        // make the wallImage active again so the player can buy another wall 
        wallImage.gameObject.SetActive(true);
    }

}
