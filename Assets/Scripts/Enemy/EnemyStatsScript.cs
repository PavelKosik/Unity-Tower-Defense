using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsScript : MonoBehaviour
{
    public TextMesh damageTextMesh;
    public TextMesh attackSpeedTextMesh;
    public TextMesh moveSpeedTextMesh;
    public Enemies enemies;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        damageTextMesh.text = enemies.damageToWall.ToString();
        attackSpeedTextMesh.text = (1 / enemies.timeToAttackWall).ToString();
        moveSpeedTextMesh.text = enemies.speed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(enemy.transform.position, Vector3.up*10,Color.red);
        Ray ray = new Ray(enemy.transform.position, Vector3.up);
        transform.position = new Vector3(ray.GetPoint(3).x,ray.GetPoint(3).y,-15);
        transform.rotation =Quaternion.Euler(0-enemy.transform.rotation.x, 0 - enemy.transform.rotation.y, 0 - enemy.transform.rotation.z);
    }
}
