using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceWall : MonoBehaviour
{
    public bool placed;
    public LayerMask placebleLayer;
    public int unplacebleLayerMaskInt;
    private SpawnButtonScript spawnButtonScript;
    private TurretAttackEnemiesScript turretAttackEnemiesScript;
    private PathCreator pathCreator;
    private BlockedPositionWallScript blockedPositionWallScript;
    public Image wallImage; // the reference is set in SpawnButtonScript

    // Start is called before the first frame update
    void Start()
    {
        spawnButtonScript = FindObjectOfType<SpawnButtonScript>();       
        blockedPositionWallScript = FindObjectOfType<BlockedPositionWallScript>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
        //wall follows the mouse cursor until it is placed in the world
        if (placed==false) {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
           
        }

        //once player clicks the left mouse button the wall checks if it can be placed on the position player tried to spawn it on
        //the wall can only be spawned on the enemy paths
        if(Input.GetMouseButtonDown(0))
        {
            if (placed==false)
            {
                
                Vector3 positionToBePlacedAt = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                Ray ray = new Ray(positionToBePlacedAt, transform.forward);
                RaycastHit2D[] hit;
                hit = Physics2D.RaycastAll(ray.origin,ray.direction,1000,placebleLayer);

                if (Physics2D.Raycast(ray.origin,ray.direction)) {

                    WallScript wallScript = GetComponent<WallScript>();
                    wallScript.placed = true;
                    pathCreator = hit[0].collider.GetComponent<PathCreator>();

                    Vector3 pointOnPath = pathCreator.path.GetClosestPointOnPath(transform.position);

                    if (blockedPositionWallScript.PositionOpen(pointOnPath)) {

                        transform.position = pointOnPath;


                        Vector3 pointBefore = pathCreator.path.GetPointAtTime(pathCreator.path.GetClosestTimeOnPath(transform.position) - 0.01f);
                        Ray rayToPoint = new Ray(transform.position, pointBefore - transform.position);

                        Quaternion lookRotation = Quaternion.LookRotation(transform.forward, rayToPoint.direction);
                        transform.rotation = lookRotation;


                        gameObject.layer = unplacebleLayerMaskInt;
                        placed = true;
                        spawnButtonScript.spawning = false;
                        spawnButtonScript.spawnedGameObject = null;
                        spawnButtonScript.cancelSpawnButton.gameObject.SetActive(false);
                        wallImage.gameObject.SetActive(true);


                    }
                    
                }
                
                               
            }
        }

        
    }
}
