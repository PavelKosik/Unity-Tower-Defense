using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KotlikTurretScript : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Animator anim;
    public bool called;
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        called = false;
        anim.SetBool("VylitKotlik", true);

    }

    // Update is called once per frame
    void Update()
    {
       

        if (called&& skinnedMeshRenderer.GetBlendShapeWeight(0)<=100) {
            skinnedMeshRenderer.SetBlendShapeWeight(0, skinnedMeshRenderer.GetBlendShapeWeight(0)+speed*Time.deltaTime);
        }

       
    }

    public void Call()
    {
        called = true;
    }
}
