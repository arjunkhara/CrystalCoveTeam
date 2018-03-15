using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float movespeed;
    private string MovementAxisName;
    private string LeftRightAxisName;
    private Rigidbody rb;
    private float MovementInputValue;
    private float LeftRightInputValue;

    public GameObject Drone;
    LevelManager LM;


    public int FullCanister = 1;
    public int CurrentCanister1Energy;
    public int CurrentCanister2Energy;
    public int CurrentCanister3Energy;

    public Slider Canister1;
    public Slider Canister2;
    public Slider Canister3;

    public bool Canister1hasbeenused;
    public bool Canister2hasbeenused;
    public bool Canister3hasbeenused;





    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        MovementInputValue = 0f;
        LeftRightInputValue = 0f;
        LM = FindObjectOfType<LevelManager>();
        CurrentCanister1Energy = FullCanister;
        CurrentCanister2Energy = FullCanister;
        CurrentCanister3Energy = FullCanister;
        Canister1hasbeenused = false;
        Canister2hasbeenused = false;
        Canister3hasbeenused = false;
 
    }

    private void Start()
    {
        MovementAxisName = "Vertical";
        LeftRightAxisName = "Horizontal";
        CurrentCanister1Energy = FullCanister;
        CurrentCanister2Energy = FullCanister;
        CurrentCanister3Energy = FullCanister;

    }

    private void Update()
    {

        





        if(LM.IsthereaDrone == true)
        {
            Drone.SetActive(true);
            movespeed = 0;
        }

        else if(LM.IsthereaDrone == false)
        {
            Drone.SetActive(false);
            movespeed = 5;
        }
        MovementInputValue = Input.GetAxis(MovementAxisName);
        LeftRightInputValue = Input.GetAxis(LeftRightAxisName);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = transform.forward * MovementInputValue * movespeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        Vector3 LeftRight = transform.right * LeftRightInputValue * movespeed * Time.deltaTime;
        rb.MovePosition(rb.position + LeftRight);
    }

    private void SetHealthUI()
    {
        Canister1.value = CurrentCanister1Energy;
        Canister2.value = CurrentCanister2Energy;
        Canister3.value = CurrentCanister3Energy;

    }

}
