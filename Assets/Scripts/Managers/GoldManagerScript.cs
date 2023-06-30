using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManagerScript : MonoBehaviour
{
    [HideInInspector]
    public float numberOfGold;

    private Text numberOfGoldText;
    public int startingGold = 30;
    public TextMesh notEnoughGoldTextMesh;
    private float activeTime;
    public AudioSource notEnoughGoldAudio;
    // Start is called before the first frame update
    void Start()
    {
        notEnoughGoldTextMesh.gameObject.SetActive(false);

        numberOfGoldText = GameObject.FindGameObjectWithTag("GoldText").GetComponent<Text>();

        numberOfGold = startingGold;
    }

    // Update is called once per frame
    void Update()
    {
        numberOfGoldText.text = numberOfGold.ToString();

        //makes sure that the text mesh doesn't stay on screen forever
        if (activeTime>0)
        {
            activeTime -= Time.deltaTime;
        }

        else
        {
            notEnoughGoldTextMesh.gameObject.SetActive(false);
        }
    }

    public void HandleNotEnoughGold()
    {
        //shows player text mesh that says he has not enough gold for a set period of time
        notEnoughGoldTextMesh.gameObject.SetActive(true);
        notEnoughGoldAudio.Play();
        activeTime = 1.5f;
    }
}
