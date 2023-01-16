using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretsUpdateStatsScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public string[] updates = { "attack", "attack speed", "range" };
    public string update;
    public float updateAmount;
    public float[] costOfUpdate;
    [HideInInspector]
    public Turrets turrets;
    private GoldManagerScript goldManagerScript;
    private TurretsStatsUpdatePanelScript turretsStatsPanelScript;
    public int index;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        turrets = GetComponentInParent<Turrets>();
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
        turretsStatsPanelScript = GetComponentInParent<TurretsStatsUpdatePanelScript>();
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Onclick()
    {

        switch (update)
        {
            case "attack":

                if (goldManagerScript.numberOfGold >= costOfUpdate[turrets.currentNumberOfUpdatesDamage])
                {

                    if (turrets.currentNumberOfUpdatesDamage < turrets.maxNumberOfUpdatesDamage)
                    {
                        turrets.damage += updateAmount;
                        goldManagerScript.numberOfGold -= costOfUpdate[turrets.currentNumberOfUpdatesDamage];
                        turrets.currentNumberOfUpdatesDamage += 1;
                        turretsStatsPanelScript.UpdateStats();
                    }

                    else
                    {
                        goldManagerScript.HandleNotEnoughGold();
                    }

                }

                break;

            case "attack speed":

                if (goldManagerScript.numberOfGold >= costOfUpdate[turrets.currentNumberOfUpdatesAttackSpeed])
                {
                    if (turrets.currentNumberOfUpdatesAttackSpeed < turrets.maxNumberOfUpdatesAttackSpeed)
                    {
                        turrets.timeBetweenAttacks -= updateAmount;
                        goldManagerScript.numberOfGold -= costOfUpdate[turrets.currentNumberOfUpdatesAttackSpeed];
                        turrets.currentNumberOfUpdatesAttackSpeed += 1;
                        turretsStatsPanelScript.UpdateStats();
                    }

                    else
                    {
                        goldManagerScript.HandleNotEnoughGold();
                    }

                }

                break;

            case "range":

                if (goldManagerScript.numberOfGold >= costOfUpdate[turrets.currentNumberOfUpdatesRange])
                {
                    if (turrets.currentNumberOfUpdatesRange < turrets.maxNumberOfUpdatesRange)
                    {
                        turrets.range += updateAmount;
                        goldManagerScript.numberOfGold -= costOfUpdate[turrets.currentNumberOfUpdatesRange];
                        turrets.currentNumberOfUpdatesRange += 1;
                        turretsStatsPanelScript.UpdateStats();
                    }
                }

                else
                {
                    goldManagerScript.HandleNotEnoughGold();
                }

                break;

        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {

        anim.SetInteger("Index", index);
        anim.SetBool("Clicked", true);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        anim.SetBool("Clicked", false);
    }

    private void OnMouseUpAsButton()
    {
        Onclick();
    }
}
