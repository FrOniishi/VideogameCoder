using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    //References
    public Image barLife;

    //Variables
    public static float actualLife;
    public static float maxLife = 100f;

    void Update()
    {
        actualLife = Player.playerLife;
        barLife.fillAmount = actualLife / maxLife;
    }
}
