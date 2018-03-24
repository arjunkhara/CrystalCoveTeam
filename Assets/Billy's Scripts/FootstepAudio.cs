using UnityEngine;
using System.Collections;

public class FootstepAudio : AudioEvent
{
    [SerializeField] float interval = 0.5f;
    float timer = 0f;

	// Update is called once per frame
	void Update()
    {   timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) {
            

            if (timer > interval)
            {
                PlaySound();
                timer = 0f;

            }  
        }



	}
}
