using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillEnergy : MonoBehaviour {

    public int startingenergy = 0;
    public int OurEnergy;
    public Slider EnergySlider;
    public Image FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;


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
        SetHealthUI();
        isFiring = true;
    }


    void OnEnable () {
        SetHealthUI();
        EnergySlider.value = OurEnergy;
	}

    private void Update()
    {
        SetHealthUI();
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
    private void SetHealthUI()
    {
        EnergySlider.value = OurEnergy;
       
    }

}
