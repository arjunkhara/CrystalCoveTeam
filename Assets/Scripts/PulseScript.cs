using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour {

    
    public int movementspeed;
    public float Timer;
    private float rotatespeed = 500000f;
    Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.velocity = transform.forward * movementspeed;
    }


    void Update () {
        transform.position += transform.forward * Time.deltaTime * movementspeed;
        Quaternion turnRotation = Quaternion.Euler(rotatespeed, rotatespeed, rotatespeed);
        RB.MoveRotation(RB.rotation * turnRotation);



        Timer -= Time.deltaTime;

      /*  if(Timer <= 0)
        {
            Destroy(this);
        }*/


    }
}
