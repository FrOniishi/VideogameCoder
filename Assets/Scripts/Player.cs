using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    //References
    public Animator Ani;
    public GameObject player;
    public CharacterController Controller;
    public Transform cam;

    //Variables
    public float speed = 3;
    public float wSpeed = 5;
    public float rSpeed = 9;
    public float turnSmoothTime = 0.01f;
    public static float playerLife = 100f;
    float turnSmoothVelocity;

    private void FixedUpdate()
    {
        Move();
    }

    void Move ()
    {   

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 inputPlayer = new Vector3(hor, 0, ver).normalized;

        if(inputPlayer.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputPlayer.x, inputPlayer.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Controller.Move(moveDir * speed * Time.fixedDeltaTime);
        }

        if (inputPlayer != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            //Walk
            Walk();
        }
        else if (inputPlayer != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            //Run
            Run();
        }
        else if (inputPlayer == Vector3.zero)
        {
            //Idle
            Idle();
        }

    }

    private void Idle ()
    {
        Ani.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk ()
    {
        speed = wSpeed;
        Ani.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

    }

    private void Run ()
    {
        speed = rSpeed;
        Ani.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

}
