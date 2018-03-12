using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour {

    public GameObject Holo;
    public bool ison;

	void Start () {
        Holo.SetActive(false);
        ison = false;

    }
	
	
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Holo.SetActive(true);
            ison = true;
        }
        else
        {
            Holo.SetActive(false);
            ison = false;
        }
		
	}
}
