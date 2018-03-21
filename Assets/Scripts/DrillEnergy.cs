using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillEnergy : MonoBehaviour {

    public int startingenergy = 0;
    public float OurEnergy;



    public Transform SpawnPulse;
    public GameObject PulseClone;
    public bool isFiring;
 


    void Start () {
        OurEnergy = startingenergy;
        isFiring = false;
	}

    public void FirePulse()
    {

        PulseClone = (GameObject)Instantiate(PulseClone, SpawnPulse.position, SpawnPulse.rotation);
        OurEnergy = 0;

        isFiring = true;
    }

    private void Update()
    {

        if (OurEnergy >= 100)
        {
            OurEnergy = 100;
        }

        else if (OurEnergy <= 0)
        {
            OurEnergy = 0;
        }

        if (OurEnergy >= 100 && Input.GetMouseButton(1) && Input.GetMouseButton(0))
        {
            FirePulse();
           
        }
        else
        {
            isFiring = false;
        }
    }
  

}
