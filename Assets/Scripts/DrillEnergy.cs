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


    public Transform FirePulse;
    public GameObject Pulse;


    void Start () {
        OurEnergy = startingenergy;
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
    }
    private void SetHealthUI()
    {
        EnergySlider.value = OurEnergy;
        FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, OurEnergy/ startingenergy);
    }

}
