using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonScript : MonoBehaviour
{
    public GameObject settingsMenu;
    private bool open=false;
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
        //closes and opens the settingsMenu based on it's previous state
        open = !open;

        if (open)
        {
            settingsMenu.SetActive(true);
        }

        else
        {
            settingsMenu.SetActive(false);
        }

        yield return new WaitForEndOfFrame();
    }

}
