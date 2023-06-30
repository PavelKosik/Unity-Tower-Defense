using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileScript : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject enemyToAttack;
    public string turretTag;
    private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lifeTime = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(transform.position, enemyToAttack.transform.position - transform.position);

        if (turretTag == "ArrowTurret")
        {
            Quaternion rotation = Quaternion.LookRotation(ray.direction, transform.forward);
            transform.rotation = rotation;
        }

        rb.velocity = ray.direction * Time.deltaTime * 5000;

        // on higher attack speed turrets shoot too many projectiles so not all of them hit the enemies
        // when that happens the projectile was stuck there existing forever
        // this lifeTime value fixes that
        if (lifeTime > 0.0f)
        {
            lifeTime -= Time.deltaTime;
        }

        else
        {
            gameObject.SetActive(false);
        }

    }
}
