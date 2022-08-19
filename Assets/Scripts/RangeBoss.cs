using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBoss : MonoBehaviour
{
    //References
    public Animator Ani;
    public Boss boss;

    //Variables
    public int melee;

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            melee = Random.Range(0, 4);
            switch (melee)
            {
                case 0:
                    
                    //Strike 1
                    Ani.SetFloat("Skills", 0);
                    boss.hitSelect = 0;
                    break;
                case 1:

                    //Strike 2
                    Ani.SetFloat("Skills", 0.2f);
                    boss.hitSelect = 1;
                    break;
                case 2:

                    //Jump 
                    Ani.SetFloat("Skills", 0.4f);
                    boss.hitSelect = 2;
                    break;
                case 3:

                    //Fire Ball
                    if(boss.phase == 2)
                    {
                        Ani.SetFloat("Skills", 1);
                    }
                    else
                    {
                        melee = 0;
                    }
                    break;

            }
            Ani.SetBool("Walk", false);
            Ani.SetBool("Run", false);
            Ani.SetBool("Attack", true);
            boss.Attacking = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
