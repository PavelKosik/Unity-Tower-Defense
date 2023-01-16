using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButtonHoverScript : MonoBehaviour
{
    
    public SpawnButtonScript spawnButtonScript;
    // Start is called before the first frame update
    void Awake()
    {
        
        spawnButtonScript = GetComponent<SpawnButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
 }
