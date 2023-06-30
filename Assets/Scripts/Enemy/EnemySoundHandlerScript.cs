using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundHandlerScript : MonoBehaviour
{
    public AudioSource goldSound;
    private EnemyBehavior enemyBehavior;
    public string goldSoundTag;
    // Start is called before the first frame update
    void Start()
    {
        enemyBehavior = GetComponent<EnemyBehavior>();
        goldSound = GameObject.FindGameObjectWithTag(goldSoundTag).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //plays the gold sound once enemy is killed to notify the player he has gotten the money from the enemy
    public void PlayGoldSound()
    {
        goldSound.Play();
    }

}
