using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    Coroutine zoomCoroutine;
    LevelManager LM;
    public float timer = 1;
    

    void Start()
    {
        LM = FindObjectOfType<LevelManager>();
    }


    void Update()
    {
     
        if(timer <= 0)
        {
            //Stop old coroutine
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);

            //Start new coroutine and zoom within 1 second
            zoomCoroutine = StartCoroutine(lerpFieldOfView(cam, 60, 1f));
        }

        if(LM.IsthereaDrone == false)
        {
            timer = 1;

        }
        
        if(LM.IsthereaDrone == true)
        {
            timer -= Time.deltaTime;
        }


    }


    IEnumerator lerpFieldOfView(Camera targetCamera, float toFOV, float duration)
    {
        float counter = 0;

        float fromFOV = targetCamera.fieldOfView;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float fOVTime = counter / duration;
            Debug.Log(fOVTime);

            //Change FOV
            targetCamera.fieldOfView = Mathf.Lerp(fromFOV, toFOV, fOVTime);
            //Wait for a frame
            yield return null;
        }
    }
}
