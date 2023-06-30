using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SettingsImageScript : MonoBehaviour //,IPointerUpHandler
{
    public PauseMenuManagerScript pauseMenuManagerScript;
    public GameObject pauseMenu;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      
   
    public IEnumerator OnInvoke()
    {
       //opens or closes the pauseMenu based on the previous state of it
        pauseMenuManagerScript.open = !pauseMenuManagerScript.open;

        if (pauseMenuManagerScript.open)
        {
            pauseMenu.SetActive(true);
        }

        else
        {
            pauseMenu.SetActive(false);
        }

        yield return new WaitForEndOfFrame();
    }
}
