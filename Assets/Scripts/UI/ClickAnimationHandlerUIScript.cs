using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAnimationHandlerUIScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
{
    private Animator anim;
    //public float animLength; unused var
    public MonoBehaviour script;
    public bool hover;
    //public StatsCloseButtonScript statsCloseButtonScript; unused var

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {   
        // sets the icon animation into hover state
        anim.SetBool("Clicked", true);              
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        // sets the icon animation out of the hover state
        anim.SetBool("Clicked", false);

        // plays the out of hover animation and does the action the icon represents
        if (script != null&&hover)
        {
            script.StartCoroutine("OnInvoke");
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        hover = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        hover = false;
    }
   
}
