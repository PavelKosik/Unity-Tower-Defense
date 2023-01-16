using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineIconScript : MonoBehaviour
{
  
    public MineScript mineScript;
    public GoldManagerScript goldManagerScript;
    private Animator anim;
    public GameObject mineUpdatePanel;
    private ClickAnimationHandlerUIScript clickAnimationHandlerUIScript;
    // Start is called before the first frame update
    void Start()
    {
        mineScript = GetComponentInParent<MineScript>();
        anim = GetComponent<Animator>();
        clickAnimationHandlerUIScript = GetComponent<ClickAnimationHandlerUIScript>();
        mineUpdatePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mineScript.build) {

            if (clickAnimationHandlerUIScript.hover && mineUpdatePanel.activeInHierarchy == false)
            {
                mineUpdatePanel.SetActive(true);
            }

            else if (clickAnimationHandlerUIScript.hover == false && mineUpdatePanel.activeInHierarchy)
            {
                mineUpdatePanel.SetActive(false);
            }
        }
    }

    public IEnumerator OnInvoke()
    {
        if (mineScript.build==false)
        {
            if (goldManagerScript.numberOfGold>=mineScript.buildCost)
            {
                BuildMine();
            }

            else
            {
                goldManagerScript.HandleNotEnoughGold();
            }
        }

        else
        {
            if (goldManagerScript.numberOfGold>=mineScript.updateCost)
            {
                UpdateMine();
            }
        }

        yield return new WaitForEndOfFrame();
    }

    void BuildMine()
    {
        mineScript.build = true;
        anim.SetBool("Build", true);
        goldManagerScript.numberOfGold -= mineScript.buildCost;
    }

    void UpdateMine()
    {
        goldManagerScript.numberOfGold -= mineScript.updateCost;
        mineScript.updateCost += mineScript.updateCostGrowth;
        mineScript.miningCrystalAmount += mineScript.updateMiningCrystalAmountIncrease;
        mineScript.miningTime -= mineScript.updateMiningTimeDecrease;
    }
}
