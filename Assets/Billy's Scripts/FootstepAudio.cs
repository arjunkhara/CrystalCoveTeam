using UnityEngine;
using System.Collections;

public class FootstepAudio : AudioEvent
{
    [SerializeField] float interval = 0.5f;
    float timer = 0f;
    LevelManager LM;


    private void Start()
    {
        LM = FindObjectOfType<LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {   timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.W) && LM.IsthereaDrone == false || Input.GetKey(KeyCode.A) && LM.IsthereaDrone == false|| Input.GetKey(KeyCode.D) && LM.IsthereaDrone == false || Input.GetKey(KeyCode.S) && LM.IsthereaDrone == false) {
            

            if (timer > interval)
            {
                PlaySound();
                timer = 0f;

            }  
        }



	}
}
