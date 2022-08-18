using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    //Reference
    public GameObject winMenu;

    //Variable
    public bool winActive;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
            winActive = true;
        }
    }
}
