using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float health;
    public int cost;
    public GameObject wallHealthImage;
    public GameObject wallHealthImageParent;
    // Start is called before the first frame update
    void Start()
    {
        wallHealthImageParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
