using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealthTextMeshScript : MonoBehaviour
{
    //used to get information about wall max and current health
    private WallScript wallScript; 
    public TextMesh healthTextMesh;
    // Start is called before the first frame update
    void Start()
    {
        wallScript = GetComponent<WallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        healthTextMesh.text = (wallScript.currentHealth+"/"+wallScript.maxHealth).ToString();
    }
}
