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
    public Slider Canister1;
    public bool Canister1hasbeenused;


    public bool isCanister1beingused;
    public float TimeofBoost = 2;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        MovementInputValue = 0f;
        LeftRightInputValue = 0f;
        LM = FindObjectOfType<LevelManager>();
        CurrentCanister1Energy = FullCanister;
        Canister1hasbeenused = false;
        isCanister1beingused = false;
        

 
    }

    private void Start()
    {
        MovementAxisName = "Vertical";
        LeftRightAxisName = "Horizontal";
        CurrentCanister1Energy = FullCanister;

    }


    void BoostOne()
    {
        if(Canister1hasbeenused == false && Input.GetKey(KeyCode.Space))
        {
            isCanister1beingused = true;
            if(isCanister1beingused == true)
            {
                TimeofBoost -= Time.deltaTime;
                movespeed = 10;
                
            }

            if(TimeofBoost <= 0)
            {
                TimeofBoost = 0;
                isCanister1beingused = false;
                Canister1hasbeenused = true;
                movespeed = 5;
            }
        }
    }




    private void Update()
    {
        BoostOne();

        if(LM.IsthereaDrone == true)
        {
            Drone.SetActive(true);
            movespeed = 0;
        }


        else
        {
            Drone.SetActive(false);
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
    }

}
