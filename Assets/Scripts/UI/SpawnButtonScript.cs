using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButtonScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    public LayerMask placebleLayer;
   
    public int unplaceblelayerInt;
    public bool spawning;
    
    private GoldManagerScript goldManagerScript;
    public float costOfTheWall;
    public Button cancelSpawnButton;

    //this is used for deactivating the turret GameObject in CancelSpawn function in CancelSpawnButtonScript
    public GameObject spawnedGameObject; 

    public Text wallCostText;
    public Image wallImage;

    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
        cancelSpawnButton.gameObject.SetActive(false);
        wallCostText.text = costOfTheWall.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //only can spawn if there is not other wall being spawned at the moment
        if (spawning==false) {
            //the wall can only be spawned if the player has enough gold to do so
            if (goldManagerScript.numberOfGold>= costOfTheWall) {
                //enables player to cancel the wall spawn if case the doesn't want to spawn the wall anymore
                cancelSpawnButton.gameObject.SetActive(true);
                //removes the player gold and setups the wall to be functional
                goldManagerScript.numberOfGold -= costOfTheWall;
                GameObject inst = StaticClass.SpawnGameObject(objectToSpawn);
                PlaceWall placeTurret = inst.AddComponent<PlaceWall>();
                placeTurret.placebleLayer = placebleLayer;
                placeTurret.unplacebleLayerMaskInt = unplaceblelayerInt;
                placeTurret.wallImage = wallImage;
                
                spawnedGameObject = inst;
                spawning = true;

                wallImage.gameObject.SetActive(false);
            }
            //if player doesn't have enough gold to buy the wall he is notified of that fact
            else
            {
                goldManagerScript.HandleNotEnoughGold();
            }
        }

        
    }
}
