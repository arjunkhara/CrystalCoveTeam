using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioEvent : MonoBehaviour {

    [FMODUnity.EventRef]
    public string fmodEvent;

    public FMOD_StudioEventEmitter emitter;

	private void Start()
	{
        emitter = GetComponent<FMOD_StudioEventEmitter>();
	}

	// Update is called once per frame
	public void PlaySound () {
        FMODUnity.RuntimeManager.PlayOneShot(fmodEvent);
	}
}
