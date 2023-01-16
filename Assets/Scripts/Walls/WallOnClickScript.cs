using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WallOnClickScript : MonoBehaviour, IPointerDownHandler
{
    private PlaceWall placeWall;
    public GameObject wallStats;
    public WallStatsManagerScript wallStatsManager;
    // Start is called before the first frame update
    void Start()
    {
        wallStatsManager = FindObjectOfType<WallStatsManagerScript>();
        placeWall = GetComponent<PlaceWall>();
        wallStats.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (wallStatsManager.currentActiveWallStatsPanel != gameObject && wallStats.activeInHierarchy)
        {
            wallStats.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (placeWall.placed) {
            if (wallStatsManager.currentActiveWallStatsPanel == gameObject)
            {

                //enemyStats.SetActive(true);
                wallStats.SetActive(false);
                wallStatsManager.currentActiveWallStatsPanel = null;
            }

            else
            {
                //enemyStats.SetActive(false);
                wallStatsManager.currentActiveWallStatsPanel = gameObject;
                wallStats.SetActive(true);
            }
        }
    }
}
