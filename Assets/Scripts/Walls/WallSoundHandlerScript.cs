using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSoundHandlerScript : MonoBehaviour
{
    private AudioSource[] takenDamageSound;
    public AudioClip[] takenDamageSoundClips;
    // Start is called before the first frame update
    void Start()
    {
        takenDamageSound = new AudioSource[takenDamageSoundClips.Length];
        for (int i=0; i<takenDamageSoundClips.Length;i++)
        {

            takenDamageSound[i] = gameObject.AddComponent<AudioSource>();
            takenDamageSound[i].clip = takenDamageSoundClips[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayTakenDamageSound()
    {
        //if any wall sound is playing we let it end before playing another one
        for (int i =0; i<takenDamageSound.Length; i++)
        {
            if (takenDamageSound[i].isPlaying) {
                return;
            }
        }


        int index = Random.Range(0, takenDamageSound.Length);
        takenDamageSound[index].Play();
        
    }
}
