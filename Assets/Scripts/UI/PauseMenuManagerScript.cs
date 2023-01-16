using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManagerScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            open = !open;

            if (open)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }

            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }


        if (open)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
