using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public bool build;
    public MineIconScript mineIconScript;
    public float buildCost;
    public float updateCost;
    public float updateCostGrowth;
    public float miningCrystalAmount;
    public float miningTime;
    public float currentMiningTime;
    private CrystalManagerScript crystalManagerScript;
    public TextMesh costText;
    public float updateMiningCrystalAmountIncrease;
    public float updateMiningTimeDecrease;
    public TextMesh crystalAmountText;
    // Start is called before the first frame update
    void Start()
    {
        crystalManagerScript = FindObjectOfType<CrystalManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        crystalAmountText.text = (miningCrystalAmount+updateMiningCrystalAmountIncrease).ToString();

        if (build)
        {
            costText.text = updateCost.ToString();

            if (currentMiningTime>=0)
            {
                currentMiningTime -= Time.deltaTime;
            }

            else
            {
                crystalManagerScript.numberOfCrystals += miningCrystalAmount;
                currentMiningTime = miningTime;
            }
        }

        else
        {
            costText.text = buildCost.ToString();
        }
    }
}
