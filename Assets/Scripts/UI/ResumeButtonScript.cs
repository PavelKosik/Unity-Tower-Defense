using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonScript : MonoBehaviour
{
   
    public GameObject pauseMenu;
    public PauseMenuManagerScript pauseMenuManagerScript;
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
        pauseMenu.SetActive(false);
        pauseMenuManagerScript.open = false;
        yield return new WaitForEndOfFrame();
    }
}
