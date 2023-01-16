using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUpdateStatsManager : MonoBehaviour
{
    public float healthUpdateAmount;
    public float healthRegenUpdateAmount;
    private WallScript wallScript;
    public TextMesh healthTextMesh;
    public TextMesh healthRegenTextMesh;


    // Start is called before the first frame update
    void Start()
    {
        wallScript = GetComponentInParent<WallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        wallScript.maxHealth += healthUpdateAmount;
        wallScript.currentHealth += healthUpdateAmount;
        healthTextMesh.text = wallScript.maxHealth.ToString(); 
    }

    public void UpdateHealthRegen()
    {
        wallScript.healthRegen += healthRegenUpdateAmount;
        healthRegenTextMesh.text = wallScript.healthRegen.ToString();
    }
}
