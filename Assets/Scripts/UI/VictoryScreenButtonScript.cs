using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool hover;
    private Animator anim;
    public bool clicked;
    public string buttonType;
    public Scene sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        sceneToLoad = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //makes the button play clicked animation
        anim.SetBool("Clicked", true);
      
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        anim.SetBool("Clicked", false);
        
        //chooses the proper action to do based on the button type
        if (buttonType == "Retry")
        {
            SceneManager.LoadSceneAsync(sceneToLoad.buildIndex);
        }

        if (buttonType == "Quit")
        {
            Application.Quit();
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
