using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBoss : MonoBehaviour
{
    //Variables
    public int damage;
    public bool loseActive;

    //References
    public Animator Ani;
    public GameObject loseMenu;

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            Player.playerLife -= damage;

            if(Player.playerLife <= 0)
            {
                Ani.SetTrigger("Death");
                loseMenu.SetActive(true);
                Time.timeScale = 0;
                loseActive = true;
            }
        }
    }
}
