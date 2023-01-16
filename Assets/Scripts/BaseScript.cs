using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseScript : MonoBehaviour
{
    public int health;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.FindGameObjectWithTag("BaseHealthText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();

        if (health<=0)
        {
            //if the health of player base reaches 0 we pause the game loop
            Time.timeScale = 0;
        }
    }
}
