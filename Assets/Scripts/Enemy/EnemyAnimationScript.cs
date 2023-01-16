using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{
    private Animator anim;
    private EnemyBehavior enemyBehavior;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyBehavior = GetComponent<EnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBehavior!=null && enemyBehavior.pathFollower!=null) {

            anim.SetFloat("Health", enemyBehavior.health);
            
            anim.SetBool("Attacking", enemyBehavior.pathFollower.attacking);
        }
    }
}
