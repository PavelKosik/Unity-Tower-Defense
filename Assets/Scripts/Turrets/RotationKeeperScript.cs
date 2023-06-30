using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RotationKeeperScript : MonoBehaviour
{

    public TurretPlacerScript turretPlacerScript;
    // Start is called before the first frame update
    void Start()
    {
        turretPlacerScript = GetComponent<TurretPlacerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //properly rotates the turrets
        turretPlacerScript.buildIcon.transform.rotation = Quaternion.Euler(turretPlacerScript.buildIcon.transform.rotation.x, turretPlacerScript.buildIcon.transform.rotation.y, transform.rotation.z);
        
        for(int i=0; i<turretPlacerScript.turrets.Length;i++)
        {
            turretPlacerScript.turrets[i].transform.rotation = Quaternion.Euler(turretPlacerScript.turrets[i].transform.rotation.x, turretPlacerScript.turrets[i].transform.rotation.y, transform.position.z);
        }     
    }
}
