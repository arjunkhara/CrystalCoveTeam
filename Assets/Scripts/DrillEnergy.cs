using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillEnergy : MonoBehaviour {

    public int startingenergy = 0;
    public int currentEnergy;
    public Slider EnergySlider;
    public Image FillImage;



	void Start () {
        currentEnergy = startingenergy;
	}
	
	void OnEnable () {
        EnergySlider.value = currentEnergy;
	}
}
