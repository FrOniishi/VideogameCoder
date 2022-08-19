using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //References
    public Animator Ani;
    public Quaternion Angle;
    public GameObject Target;
    public GameObject[] Hit;
    public RangeBoss range;
    public Image barLife;
    public AudioSource music;

    //Variables
    public int Rutine;
    public float Timer;
    public float TimeRutine;
    public float Grade;
    public bool Attacking;
    public float Speed;
    public int hitSelect;
    public int phase = 1;
    public float HPMin;
    public float HPMax;
    public bool dead;

    //Flamethrower
    public bool flamethrower;
    public List<GameObject> pool = new List<GameObject>();
    public GameObject fire;
    public GameObject head;
    private float Timer2;

    //Jump Attack
    public float jumpDistance;
    public bool directionSkill;

    //Fire Ball
    public GameObject fireBall;
    public GameObject point;
    public List<GameObject> pool2 = new List<GameObject>();

    private void Start()
    {
        Ani = GetComponent<Animator>();
        Target = GameObject.Find("Player (Arthur)");
    }

    private void Update()
    {
        barLife.fillAmount = HPMin / HPMax;
        if(HPMin > 0)
        {
            Alive();
        }
        else
        {
            if (!dead)
            {
                Ani.SetTrigger("Death");
                music.enabled = false;
                dead = true;
            }
        }
    }

    public void BossBehavior()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < 15)
        {
            var lookPos = Target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(Target.transform.position);
            music.enabled = true;

            if (Vector3.Distance(transform.position, Target.transform.position) > 1 && !Attacking)
            {
                switch (Rutine)
                {
                    case 0:
                        
                        //Walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        Ani.SetBool("Walk", true);
                        Ani.SetBool("Run", false);

                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                        }

                        Ani.SetBool("Attack", false);

                        Timer += 1 * Time.deltaTime;
                        if(Timer > TimeRutine)
                        {
                            Rutine = Random.Range(0, 5);
                            Timer = 0;
                        }
                        break;
                    case 1:
                        
                        //Run
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        Ani.SetBool("Walk", false);
                        Ani.SetBool("Run", true);

                        if (transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * Speed * 2 * Time.deltaTime);
                        }

                        Ani.SetBool("Attack", false);
                        break;
                    case 2:

                        //Flamethrower
                        Ani.SetBool("Walk", false);
                        Ani.SetBool("Run", false);
                        Ani.SetBool("Attack", true);
                        Ani.SetFloat("Skills", 0.8f);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        range.GetComponent<CapsuleCollider>().enabled = false;
                        break;
                    case 3:
                         //Jump Attack
                         if(phase == 2)
                        {
                            jumpDistance += 1 * Time.deltaTime;
                            Ani.SetBool("Walk", false);
                            Ani.SetBool("Run", false);
                            Ani.SetBool("Attack", true);
                            Ani.SetFloat("Skills", 0.6f);
                            hitSelect = 3;
                            range.GetComponent<CapsuleCollider>().enabled = false;

                            if(directionSkill)
                            {
                                if (jumpDistance < 1f)
                                {
                                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                                }

                                transform.Translate(Vector3.forward * 8 * Time.deltaTime);
                            }
                        }
                         else
                        {
                            Rutine = 0;
                            Timer = 0;
                        }
                        break;
                    case 4:

                        //Fire Ball
                        if(phase == 2)
                        {
                            Ani.SetBool("Walk", false);
                            Ani.SetBool("Run", false);
                            Ani.SetBool("Attack", true);
                            Ani.SetFloat("Skills", 1);
                            range.GetComponent<CapsuleCollider>().enabled = false;
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                        }
                        else
                        {
                            Rutine = 0;
                            Timer = 0;
                        }
                        break;
                }
            }
        }
    }

    public void FinalAni()
    {
        Rutine = 0;
        Ani.SetBool("Attack", false);
        Attacking = false;
        range.GetComponent<CapsuleCollider>().enabled = true;
        flamethrower = false;
        jumpDistance = 0;
        directionSkill = false;
    }

    public void DirectionAttackStart()
    {
        directionSkill = true;
    }

    public void DirectionAttackFinal()
    {
        directionSkill = false;
    }

    //Melee

    public void ColliderWeaponTrue()
    {
        Hit[hitSelect].GetComponent<SphereCollider>().enabled = true;
    }

    public void  ColliderWeaponFalse()
    {
        Hit[hitSelect].GetComponent<SphereCollider>().enabled = true;
    }

    //Flamethrower

    public GameObject GetBall()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(fire, head.transform.position, head.transform.rotation) as GameObject;
        pool.Add(obj);
        return obj;
    }

    public void flametrthrowerSkill()
    {
        Timer2 += 1 * Time.deltaTime;
        if(Timer2 > 0.1f)
        {
            GameObject obj = GetBall();
            obj.transform.position = head.transform.position;
            obj.transform.rotation = head.transform.rotation;
            Timer2 = 0;
        }
    }

    public void StartFire()
    {
        flamethrower = true;
    }

    public void StopFire()
    {
        flamethrower = false;
    }

    //Fire Ball

    public  GameObject GetFireBall()
    {

        for (int i = 0; i < pool2.Count; i++)
        {
            if (!pool2[i].activeInHierarchy)
            {
                pool2[i].SetActive(true);
                return pool2[i];
            }
        }
        GameObject obj = Instantiate(fireBall, point.transform.position, point.transform.rotation) as GameObject;
        pool2.Add(obj);
        return obj;
    }

    public void FireBallSkill()
    {
        GameObject obj = GetFireBall();
        obj.transform.position = point.transform.position;
        obj.transform.rotation = point.transform.rotation;
    }

    public void Alive()
    {
        if (HPMin < 500)
        {
            phase = 2;
            TimeRutine = 1;
        }

        BossBehavior();

        if(flamethrower)
        {
            flametrthrowerSkill();
        }
    }
}
