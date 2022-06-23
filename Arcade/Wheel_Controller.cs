using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Controller : MonoBehaviour
{
    public GameObject[] wheelToRotate;
    public float rotationSpeed;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        foreach (var wheel in wheelToRotate)
        {
            wheel.transform.Rotate( Time.deltaTime * verticalAxis * rotationSpeed, 0, 0, Space.Self);
        }

        if (horizontalAxis > 0)
        {
            anim.SetBool("goingLeft", false);
            anim.SetBool("goingRight", true);

        }
        else if (horizontalAxis < 0)
        {
            anim.SetBool("goingLeft", true);
            anim.SetBool("goingRight", false);
        }
        else
        {
            anim.SetBool("goingLeft", false);
            anim.SetBool("goingRight", false);
        }
    }
}
