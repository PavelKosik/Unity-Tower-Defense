using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script used to setup the waves in each level
[System.Serializable]
public class WaveScript 
{
    //number of orcs spawned in the wave
    public int orcNumber;
    //time between waves are spawned one after another
    public float timeBetweenWaves;
}
