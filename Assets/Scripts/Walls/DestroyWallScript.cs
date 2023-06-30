using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallScript : MonoBehaviour
{
    private WallScript wallScript;
    private Walls walls;
    private GoldManagerScript goldManagerScript;
    private float damageTaken;
    private float destroyReturnPrice;
    private BlockedPositionWallScript blockedPositionWallScript;
    public TextMesh destroyReturnPriceTextMesh;
    // Start is called before the first frame update
    void Start()
    {
        wallScript = GetComponentInParent<WallScript>();
        walls = GetComponentInParent<Walls>();
        goldManagerScript = FindObjectOfType<GoldManagerScript>();
        blockedPositionWallScript = FindObjectOfType<BlockedPositionWallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculates the price to refund player based on the damage the wall has received
        damageTaken = wallScript.currentHealth / wallScript.maxHealth * 100;
        destroyReturnPrice = Mathf.RoundToInt(walls.cost * damageTaken / 100);
        destroyReturnPriceTextMesh.text = ("Return:" + destroyReturnPrice).ToString();
    }

    public IEnumerator OnInvoke()
    {
        //refunds player the gold and destroys the wall
        goldManagerScript.numberOfGold += destroyReturnPrice;
        wallScript.alive = false;
        wallScript.gameObject.SetActive(false);
        blockedPositionWallScript.RemovePosition(wallScript.gameObject.transform.position);
        yield return new WaitForEndOfFrame();
    }
}
