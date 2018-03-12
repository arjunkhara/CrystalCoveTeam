using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour {

    public float rotationSpeed = 99.0f;
    public bool reverse = false;
    PlayerController PC;

    public float Timer;
    public float turnTimer = 10;
    public bool Readytodrill;
    public bool isdrilling;


    private void Start()
    {
        PC = FindObjectOfType<PlayerController>();
        isdrilling = false;
        Timer = 50;
        Readytodrill = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) {
                //transform.Rotate(Vector3.back * Time.deltaTime * this.rotationSpeed);
            transform.Rotate(new Vector3(0f, 0f, 10f) * Time.deltaTime * this.rotationSpeed);
            PC.movespeed = 0;
            isdrilling = true;
        }
        else
        {
            isdrilling = false;
            PC.movespeed = 5;
        }
        if (Timer <= 0)
        {
            Timer = 0;
        }

        if (isdrilling == true && Readytodrill == true) 
        {
            Timer -= turnTimer * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Untagged")
        {
            Readytodrill = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            Readytodrill = false;
        }
    }


    public void SetRotationSpeed(float speed)
    {
        this.rotationSpeed = speed;
    }

    public void SetReverse(bool reverse)
    {
        this.reverse = reverse;
    }
}
