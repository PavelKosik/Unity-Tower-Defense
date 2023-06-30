using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretPlacerScript : MonoBehaviour
{
    public GameObject[] turrets;
    private bool pressed;
    public GameObject buildIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
       

        CloseTurretMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }   
    
    public IEnumerator OnInvoke()
    {
        pressed = !pressed;

        if (pressed == true)
        {
            OpenTurretMenu();
        }

        else
        {
            CloseTurretMenu();
        }

        yield return new WaitForEndOfFrame();
    }

   
    //opens the turret select menu
    void OpenTurretMenu()
    {
        for (int i=0;i<turrets.Length;i++)
        {
            turrets[i].SetActive(true);
        }
    }

    //closes the turret select menu
    void CloseTurretMenu()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            turrets[i].SetActive(false);
        }
    }
}
