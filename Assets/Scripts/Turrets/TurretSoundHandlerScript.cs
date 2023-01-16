using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSoundHandlerScript : MonoBehaviour
{
    private AudioSource projectileSound;
    public string audioSourceTag;
    // Start is called before the first frame update
    void Start()
    {
        projectileSound = GameObject.FindGameObjectWithTag(audioSourceTag).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayProjectileSound()
    {
        projectileSound.Play();
    }
}
