using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour {

    
    public int movementspeed;
    public float Timer;

    void Update () {
        transform.position += transform.forward * Time.deltaTime * movementspeed;

        Timer -= Time.deltaTime;

        if(Timer <= 0)
        {
            Destroy(this);
        }


    }
}
