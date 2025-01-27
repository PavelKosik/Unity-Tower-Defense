﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public GameObject levelSelectMenu;
    public GameObject startMenu;
    public GameObject buttons;
    private bool open = false;
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
        //handles the behaviour of the level select menu
        open = !open;

        if (open)
        {
            levelSelectMenu.SetActive(true);
            buttons.SetActive(false);
            startMenu.GetComponent<SpriteRenderer>().sprite = null;
        }

        else
        {
            levelSelectMenu.SetActive(false);
        }

        yield return new WaitForEndOfFrame();
    }
}
