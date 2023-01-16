using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretStatsPanelScript : MonoBehaviour
{
    public GameObject turretStatsPanel;    
    public ClickAnimationHandlerUIScript clickAnimationHandlerUIScript;
    public TextMesh attackTextMesh;
    public TextMesh attackSpeedTextMesh;
    public TextMesh rangeTextMesh;
    public TurretSpawnScript turretSpawnScript;
    public TextMesh costTextMesh;




   

    // Start is called before the first frame update
    void Start()
    {
        turretStatsPanel.SetActive(false);
        clickAnimationHandlerUIScript = GetComponent<ClickAnimationHandlerUIScript>();

        Turrets myTurret = turretSpawnScript.turretGameObject.GetComponent<Turrets>();
        attackTextMesh.text = myTurret.damage.ToString();
        attackSpeedTextMesh.text = (1 / turretSpawnScript.turretGameObject.GetComponent<Turrets>().timeBetweenAttacks).ToString();
        rangeTextMesh.text = myTurret.range.ToString();
        costTextMesh.text = myTurret.cost.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {

        if (clickAnimationHandlerUIScript.hover)
        {
            turretStatsPanel.SetActive(true);
        }

        else
        {
            turretStatsPanel.SetActive(false);
        }
     
    }
    

}
