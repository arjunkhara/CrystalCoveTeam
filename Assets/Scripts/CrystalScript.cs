using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour {

    public float Timer;
    PlayerController PC;
    DrillEnergy DE;


	
	void Start () {
        Timer = 3;
        PC = FindObjectOfType<PlayerController>();
        DE = FindObjectOfType<DrillEnergy>();
		
	}
	

	void Update () {
        if (PC.ReadytoDrill == true && PC.touchingCrystal == true)
        {
            Timer -= Time.deltaTime;
        }

        else
        {
            Timer = 3;
        }

        if(Timer < 0)
        {
            
            DE.OurEnergy += 10 *Time.deltaTime ;
        }

        if(Timer <= -0.5)
        {
            this.gameObject.SetActive(false);
        }


		

    }
}
