using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_1: MonoBehaviour
{
    //References
    public GameObject Player;
    public GameObject Target;
    public Animator Ani;
    public Quaternion Angle;

    //Variables
    public float Grade;
    private bool Attack;
    public static float Damage = 1.5f;
    public static float lifeEnemy = 50f;
    public int Rutine;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();
        Target = GameObject.Find("Player (Arthur)");
    }

    // Update is called once per frame
    void Update()
    {
        enemys_Conduct();
    }

    void enemys_Conduct ()
    {
        if(Vector3.Distance(transform.position, Target.transform.position) > 8)
        {
            Ani.SetBool("Run", false);
            Timer += 1 * Time.deltaTime;
            if(Timer >= 3.5f)
            {
                Rutine = Random.Range(0, 2);
                Timer = 0;
            }
            switch (Rutine)
            {
                case 0:
                    Ani.SetBool("Walk", false);
                    break;

                case 1:
                    Grade = Random.Range(0, 360);
                    Angle = Quaternion.Euler(0, Grade, 0);
                    Rutine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    Ani.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > 1 && !Attack)
            {
                var lookPos = Target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                Ani.SetBool("Walk", false);

                Ani.SetBool("Run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                Ani.SetBool("Attack", false);
            }
            else
            {
                Ani.SetBool("Walk", false);
                Ani.SetBool("Run", false);

                Ani.SetBool("Attack", true);
                Attack = true;
            }
        }
    }

    void final_Ani()
    {
        Ani.SetBool("Attack", false);
        Attack = false;
    }
}
