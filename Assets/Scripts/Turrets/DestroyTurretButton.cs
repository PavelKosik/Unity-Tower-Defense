using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyTurretButton : MonoBehaviour, IPointerDownHandler
{
    public Turrets turrets;
    private GoldManagerScript goldManagerScript;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        turrets = GetComponentInParent<Turrets>();
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        /*GameObject inst = Instantiate(turrets.placer);
        inst.transform.position = turrets.placer.transform.position;
        inst.gameObject.SetActive(true);
        inst.GetComponent<TurretPlacerScript>().buildIcon.SetActive(true);
        goldManagerScript.numberOfGold += turrets.cost;
        turrets.gameObject.SetActive(false);*/
        anim.SetBool("Clicked", true);
        anim.SetInteger("Index", 4);
    }

    private void OnMouseUpAsButton()
    {
        GameObject inst = Instantiate(turrets.placer);
        inst.transform.position = turrets.placer.transform.position;
        inst.gameObject.SetActive(true);
        inst.GetComponent<TurretPlacerScript>().buildIcon.SetActive(true);
        goldManagerScript.numberOfGold += turrets.cost;
        turrets.gameObject.SetActive(false);
        anim.SetBool("Clicked", false);
    }

    private void OnMouseUp()
    {
        anim.SetBool("Clicked", false);
    }
}
