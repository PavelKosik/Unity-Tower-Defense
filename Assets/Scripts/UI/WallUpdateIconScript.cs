using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUpdateIconScript : MonoBehaviour
{
    private WallUpdateStatsManager wallUpdateStatsManager;
    public string updateValue;
    // Start is called before the first frame update
    void Start()
    {
        wallUpdateStatsManager = GetComponentInParent<WallUpdateStatsManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator OnInvoke()
    {
        switch (updateValue)
        {
            //TODO CHECK IF ENOUGH CRYSTALS
            case "health":
                wallUpdateStatsManager.UpdateHealth();             
                break;

            case "regen":
                wallUpdateStatsManager.UpdateHealthRegen();

                break;
        }
        yield return new WaitForEndOfFrame();
    }
}
