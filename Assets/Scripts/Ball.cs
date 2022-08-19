using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Timer;

    private void Update()
    {
        Timer += 1 * Time.deltaTime;
        if(Timer > 3f)
        {
            gameObject.SetActive(false);
            Timer = 0;
        }
        transform.Translate(Vector3.forward * 15 * Time.deltaTime);
    }
}
