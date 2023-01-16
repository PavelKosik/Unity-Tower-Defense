using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundHandlerScript : MonoBehaviour
{
    public AudioSource goldSound;
   // public AudioSource[] dyingSound;
    private EnemyBehavior enemyBehavior;
    public string goldSoundTag;
   // public string[] dyingSoundTag;
    // Start is called before the first frame update
    void Start()
    {
        enemyBehavior = GetComponent<EnemyBehavior>();
        goldSound = GameObject.FindGameObjectWithTag(goldSoundTag).GetComponent<AudioSource>();

       /* for (int i=0;i<dyingSoundTag.Length;i++) {
            dyingSound[i] = GameObject.FindGameObjectWithTag(dyingSoundTag[i]).GetComponent<AudioSource>();
        }
       */
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayGoldSound()
    {
        goldSound.Play();
    }

   /* public void PlayDyingSound()
    {
        int index = Random.Range(0, dyingSound.Length);
        dyingSound[index].Play();
    }*/
}
