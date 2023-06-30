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
        //closes the wall stats if player chose to open different wall's stats
        if (wallStatsManager.currentActiveWallStatsPanel != gameObject && wallStats.activeInHierarchy)
        {
            wallStats.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //handles opening / closing the stats on click
        if (placeWall.placed) {
            if (wallStatsManager.currentActiveWallStatsPanel == gameObject)
            {
                wallStats.SetActive(false);
                wallStatsManager.currentActiveWallStatsPanel = null;
            }

            else
            {
                wallStatsManager.currentActiveWallStatsPanel = gameObject;
                wallStats.SetActive(true);
            }
        }
    }
}
