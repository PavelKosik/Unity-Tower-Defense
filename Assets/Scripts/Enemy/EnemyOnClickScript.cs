using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyOnClickScript : MonoBehaviour,IPointerDownHandler
{
    public GameObject enemyStats;  
    private EnemyStatsPanelManagerScript enemyStatsPanelManager;
    // Start is called before the first frame update
    void Start()
    {
        enemyStatsPanelManager = FindObjectOfType<EnemyStatsPanelManagerScript>();
        enemyStats.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStatsPanelManager.activeEnemyStatsPanel!=gameObject&&enemyStats.activeInHierarchy)
        {
            enemyStats.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //activates / deactives the stats panel based on if it was active or not
        if (enemyStatsPanelManager.activeEnemyStatsPanel==gameObject) {
            enemyStats.SetActive(false);
            enemyStatsPanelManager.activeEnemyStatsPanel = null;
        }

        else
        {
            enemyStatsPanelManager.activeEnemyStatsPanel = gameObject;
            enemyStats.SetActive(true);
        }
    }
}
