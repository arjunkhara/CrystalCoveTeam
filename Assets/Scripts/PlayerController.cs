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





    public bool Canister1hasbeenused;
    public bool isCanister1beingused;
    public float TimeofBoost = 2;

    public bool Canister2hasbeenused;
    public bool isCanister2beingused;
    public float TimeofBoost2 = 2;

    public bool Canister3hasbeenused;
    public bool isCanister3beingused;
    public float TimeofBoost3 = 2;





    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        MovementInputValue = 0f;
        LeftRightInputValue = 0f;
        LM = FindObjectOfType<LevelManager>();
        Canister1hasbeenused = false;
        isCanister1beingused = false;
        

 
    }

    private void Start()
    {
        MovementAxisName = "Vertical";
        LeftRightAxisName = "Horizontal";
 
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



    void BoostTwo()
    {
        if (Canister2hasbeenused == false &&    Canister1hasbeenused == true && Input.GetKey(KeyCode.Space))
        {
            isCanister2beingused = true;
            if (isCanister2beingused == true)
            {
                TimeofBoost2 -= Time.deltaTime;
                movespeed = 10;

            }

            if (TimeofBoost2 <= 0)
            {
                TimeofBoost2 = 0;
                isCanister2beingused = false;
                Canister2hasbeenused = true;
                movespeed = 5;
            }
        }
    }




    void BoostThree()
    {
        if (Canister3hasbeenused == false && Canister2hasbeenused == true && Canister1hasbeenused == true && Input.GetKey(KeyCode.Space))
        {
            isCanister3beingused = true;
            if (isCanister3beingused == true)
            {
                TimeofBoost3 -= Time.deltaTime;
                movespeed = 10;

            }

            if (TimeofBoost3 <= 0)
            {
                TimeofBoost3 = 0;
                isCanister3beingused = false;
                Canister3hasbeenused = true;
                movespeed = 5;
            }
        }
    }



    private void Update()
    {
        BoostOne();
        BoostTwo();



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


}
