using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretOnClickScript : MonoBehaviour, IPointerDownHandler
{
    public GameObject statsPanel;
    private TurretsStatsPanelManagerScript turretsStatsPanelManagerScript;

    public LineRenderer line;
    [Range(0, 50)]
    public int segments = 50;


    // Start is called before the first frame update
    void Start()
    {
        turretsStatsPanelManagerScript = FindObjectOfType<TurretsStatsPanelManagerScript>();

        line = GetComponent<LineRenderer>();
        line.positionCount=segments + 1;
        line.useWorldSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (turretsStatsPanelManagerScript.currentActiveStatsPanel==statsPanel&&statsPanel.activeInHierarchy==false)
        {
            statsPanel.SetActive(true);
            line.startWidth = 0.2f;
           
        }

        else if (turretsStatsPanelManagerScript.currentActiveStatsPanel!=statsPanel&&statsPanel.activeInHierarchy)
        {
            statsPanel.SetActive(false);
            line.startWidth = 0;
        }
        CreatePoints();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (turretsStatsPanelManagerScript.currentActiveStatsPanel!=statsPanel) {

            turretsStatsPanelManagerScript.currentActiveStatsPanel = statsPanel;
            CreatePoints();
        }

        else
        {
            turretsStatsPanelManagerScript.currentActiveStatsPanel = null;            
        }
    }

    void CreatePoints()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * (statsPanel.GetComponent<TurretsStatsUpdatePanelScript>().turrets.range);
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * (statsPanel.GetComponent<TurretsStatsUpdatePanelScript>().turrets.range);
            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }
    }
}
