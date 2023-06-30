using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretsStatsUpdatePanelScript : MonoBehaviour
{
    public TextMesh attackTextMesh;
    public TextMesh attackSpeedTextMesh;
    public TextMesh rangeTextMesh;
    public Turrets turrets;
    public TextMesh numberOfUpdatesDamageTextMesh;
    public TextMesh numberOfUpdatesAttackSpeedTextMesh;
    public TextMesh numberOfUpdatesRangeTextMesh;
    public GameObject turret;

  
    // Start is called before the first frame update
    void Start()
    {
        //sets the default stats
        turrets = GetComponentInParent<Turrets>();
        attackTextMesh.text = turrets.damage.ToString();
        attackSpeedTextMesh.text = (1 / turrets.timeBetweenAttacks).ToString();
        rangeTextMesh.text = turrets.range.ToString();
        numberOfUpdatesDamageTextMesh.text = (turrets.currentNumberOfUpdatesDamage + "/" + turrets.maxNumberOfUpdatesDamage).ToString();
        numberOfUpdatesAttackSpeedTextMesh.text = (turrets.currentNumberOfUpdatesAttackSpeed + "/" + turrets.maxNumberOfUpdatesAttackSpeed).ToString();
        numberOfUpdatesRangeTextMesh.text = (turrets.currentNumberOfUpdatesRange + "/" + turrets.maxNumberOfUpdatesRange).ToString();


        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStats()
    {
        //updates the text to properly reflect the current state of updates
        attackTextMesh.text = turrets.damage.ToString();
        attackSpeedTextMesh.text = (Mathf.Round((1 / turrets.timeBetweenAttacks)*100)/100).ToString(); //rounds the number to 2 decimals        
        rangeTextMesh.text = turrets.range.ToString();
        numberOfUpdatesDamageTextMesh.text = (turrets.currentNumberOfUpdatesDamage.ToString() + "/" + turrets.maxNumberOfUpdatesDamage.ToString()).ToString();
        numberOfUpdatesAttackSpeedTextMesh.text = (turrets.currentNumberOfUpdatesAttackSpeed.ToString() + "/" + turrets.maxNumberOfUpdatesAttackSpeed.ToString()).ToString();
        numberOfUpdatesRangeTextMesh.text = (turrets.currentNumberOfUpdatesRange.ToString() + "/" + turrets.maxNumberOfUpdatesRange.ToString()).ToString();
        
    }

   
}
