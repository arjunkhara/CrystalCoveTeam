using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour {

    public float Timer;
    Drill DrillScript;
    DrillEnergy DrillEnergyScript;

	
	void Start () {
        Timer = 3;
        DrillScript = FindObjectOfType<Drill>();
        DrillEnergyScript = FindObjectOfType<DrillEnergy>();
		
	}
	

	void Update () {
        if (DrillScript.Readytodrill == true && DrillScript.isdrilling == true)
        {
            Timer -= Time.deltaTime;
        }

        else
        {
            Timer = 3;
        }

        if(Timer <= 0)
        {
            Debug.Log("Crystal Destroyed");
            DrillEnergyScript.OurEnergy += 10;
        }
		

    }
}
