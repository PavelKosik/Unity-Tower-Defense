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
        if (spawning==false) {

            if (goldManagerScript.numberOfGold>= costOfTheWall) {

                cancelSpawnButton.gameObject.SetActive(true);
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

            else
            {
                goldManagerScript.HandleNotEnoughGold();
            }
        }

        
    }
}
