﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crysal3script : MonoBehaviour {


    public float Timer;
    PlayerController PC;
    DrillEnergy DE;
    public GameObject crys;
    public bool touchingmech;


    void Start()
    {
        Timer = 3;
        PC = FindObjectOfType<PlayerController>();
        DE = FindObjectOfType<DrillEnergy>();

    }


    void Update()
    {
        if (PC.ReadytoDrill == true && PC.touchingCrystal == true && PC.touchingcrystal3 == true)
        {
            Timer -= Time.deltaTime;
        }

        else
        {
            Timer = 3;
        }

        if (Timer < 0)
        {

            DE.OurEnergy += 10 * Time.deltaTime;
        }

        if (Timer <= -0.5)
        {
            crys.SetActive(false);
        }




    }
}
