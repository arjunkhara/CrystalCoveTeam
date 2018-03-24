using UnityEngine;
using System.Collections;
using FMOD.Studio;


public class DrillAudio : AudioEvent
{
    //[SerializeField] float interval = 0.5f;
    //float timer = 0f;
    bool active = false;
    EventInstance drillEventInst;
    float drive;

	private void Start()
	{
        drillEventInst = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(drillEventInst, , GetComponent<Rigidbody>());
	}
	// Update is called once per frame
	void Update()
    {   
        if (Input.GetMouseButton(1)) 
        {
            if (!active) 
            {
                drive = 0;
                drillEventInst.start();
                active = true;
            } else {
                drive += 0.01f;
                drillEventInst.setParameterValue("drive", drive);
            }
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            drillEventInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            active = false;
            
        }
	}
}
