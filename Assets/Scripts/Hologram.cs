using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour {

    public GameObject Holo;
    public bool HoloisOn;

    void Start () {
        Holo.SetActive(false);
		
	}
	
	
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Holo.SetActive(true);
            HoloisOn = true;
        }
        else
        {
            Holo.SetActive(false);
            HoloisOn = false;
        }
		
	}
}
