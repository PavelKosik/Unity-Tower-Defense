using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCostTextScript : MonoBehaviour
{
    public TurretsUpdateStatsScript turretsUpdateStatsScript;
    private TextMesh textMesh;
    public string updateType;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (updateType)
        {
            case "attack":

                if (turretsUpdateStatsScript.turrets.currentNumberOfUpdatesDamage < turretsUpdateStatsScript.turrets.maxNumberOfUpdatesDamage)
                {
                    textMesh.text = turretsUpdateStatsScript.costOfUpdate[turretsUpdateStatsScript.turrets.currentNumberOfUpdatesDamage].ToString();
                }

                break;

            case "attack speed":

                if (turretsUpdateStatsScript.turrets.currentNumberOfUpdatesAttackSpeed < turretsUpdateStatsScript.turrets.maxNumberOfUpdatesAttackSpeed)
                {
                    textMesh.text = turretsUpdateStatsScript.costOfUpdate[turretsUpdateStatsScript.turrets.currentNumberOfUpdatesAttackSpeed].ToString();
                }

                break;

            case "range":

                if (turretsUpdateStatsScript.turrets.currentNumberOfUpdatesRange < turretsUpdateStatsScript.turrets.maxNumberOfUpdatesRange)
                {
                    textMesh.text = turretsUpdateStatsScript.costOfUpdate[turretsUpdateStatsScript.turrets.currentNumberOfUpdatesRange].ToString();
                }

                break;
        }
    }
}
