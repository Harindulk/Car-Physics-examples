using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public ScrWheel[] wheels;

    [Header("Car Specs")]
    public float wheelBase; //meters
    public float rearTrack; //meters
    public float turnRadius; //meters

    [Header("Inputs")]
    public float steerInput;

    public float AngleLeft;
    public float AngleRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steerInput = Input.GetAxis("Horizontal");

        if (steerInput > 0) //turn right
        {
            AngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            AngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
        }

        else if (steerInput < 0) //turn left
        {
            AngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            AngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
        }

        else
        {
            AngleLeft = 0;
            AngleRight = 0;
        }

        foreach (ScrWheel w in wheels)
        {
            if (w.wheelFrontLeft)
                w.steerAngle = AngleLeft;
            if (w.wheelFrontRight)
                w.steerAngle = AngleRight;
        }
    }
}
