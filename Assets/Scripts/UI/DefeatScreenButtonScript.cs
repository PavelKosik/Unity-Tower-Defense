using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatScreenButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool hover;
    private Animator anim;
    //public bool clicked; unused var
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

        anim.SetBool("Clicked", true);

    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        anim.SetBool("Clicked", false);


        if (buttonType == "Retry")
        {
            SceneManager.LoadSceneAsync(sceneToLoad.buildIndex);
            Time.timeScale = 0;
            Time.timeScale = 1;
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
