using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public Rigidbody Drone;
    public Transform SpawnDrone;
    public bool IsthereaDrone;

    public GameObject PlayerCamera;
    public PlayerController PC;
    CameraRotation ML;
    SpaceShip SS;







    void Start()
    {
        PC = FindObjectOfType<PlayerController>();
        ML = FindObjectOfType<CameraRotation>();
        IsthereaDrone = false;
        SS = FindObjectOfType<SpaceShip>();
      




    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2) && IsthereaDrone == false)
        {
        
             SS.DroneEnergy = SS.StartingEnergy;
             PlayerCamera.SetActive(false);
             IsthereaDrone = true;
             Drone.transform.position = SpawnDrone.transform.position;
             ML.enabled = false;
          
        }

        else if (IsthereaDrone == true && Input.GetMouseButtonUp(2)) {

            PlayerCamera.SetActive(true);
            ML.enabled = true;
            IsthereaDrone = false;


        }


        if(SS.DroneEnergy <= 0 && IsthereaDrone == true)
        {
           IsthereaDrone = false;
           PC.Drone.SetActive(false);
           PC.DroneCanvas.enabled = false;

        }



    }
}
