using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Variables
    public Animator Ani;
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "PlayerWeapon")
        {
            Enemy_1.lifeEnemy -= PlayerDamage.playerDamage;

            if (Enemy_1.lifeEnemy <= 0)
            {
                Ani.SetTrigger("Death");
            }
        }

        if (coll.tag == "PlayerWeapon")
        {
            Enemy_2.lifeEnemy -= PlayerDamage.playerDamage;

            if (Enemy_2.lifeEnemy <= 0)
            {
                Ani.SetTrigger("Death");
            }
        }

        if (coll.tag == "PlayerWeapon")
        {
            Enemy_3.lifeEnemy -= PlayerDamage.playerDamage;

            if (Enemy_3.lifeEnemy <= 0)
            {
                Ani.SetTrigger("Death");
            }
        }
    }
}
