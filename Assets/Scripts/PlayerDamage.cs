using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    //References
    public Animator Ani;
    public GameObject loseMenu;

    //Variables
    public bool loseActive;
    public static float playerDamage = 50f;

    void Update()
    {
        Damage();
    }

    void Damage()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ani.SetTrigger("Attack");
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Weapon")
        {
            Player.playerLife -= Enemy_1.Damage;
            Debug.Log("Damage");

            if (Player.playerLife <= 0)
            {
                Ani.SetTrigger("Death");
                loseMenu.SetActive(true);
                Time.timeScale = 0;
                loseActive = true;
            }
        }

        if (coll.tag == "Weapon")
        {
            Player.playerLife -= Enemy_2.Damage;
            Debug.Log("Damage");

            if (Player.playerLife <= 0)
            {
                Ani.SetTrigger("Death");
                loseMenu.SetActive(true);
                Time.timeScale = 0;
                loseActive = true;
            }
        }

        if (coll.tag == "Weapon")
        {
            Player.playerLife -= Enemy_3.Damage;
            Debug.Log("Damage");

            if (Player.playerLife <= 0)
            {
                Ani.SetTrigger("Death");
                loseMenu.SetActive(true);
                Time.timeScale = 0;
                loseActive = true;
            }
        }

        if(coll.CompareTag("Boss"))
        {
            coll.GetComponent<Boss>().HPMin -= playerDamage;
        }
    }

}
