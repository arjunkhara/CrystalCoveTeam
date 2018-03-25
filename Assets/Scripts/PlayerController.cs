using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    public Animator Anim;

    public float movespeed;
    private string MovementAxisName;
    private string LeftRightAxisName;
    private Rigidbody rb;
    private float MovementInputValue;
    private float LeftRightInputValue;

    public GameObject Drone;
    LevelManager LM;

    public bool ReadytoDrill;
    public bool touchingCrystal;

    DrillEnergy DE;

    public Canvas DroneCanvas;
    SpaceShip SS;



    public bool touchingcrystal2;
    public bool touchingcrystal3;
    public bool touchingcrystal4;
    public bool touchingcrystal5;




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

     

        DroneCanvas.enabled = false;
        rb = GetComponent<Rigidbody>();
        MovementInputValue = 0f;
        LeftRightInputValue = 0f;
        LM = FindObjectOfType<LevelManager>();
        Canister1hasbeenused = false;
        isCanister1beingused = false;

        Anim = GetComponent<Animator>();


        ReadytoDrill = false;
        touchingCrystal = false;

        DE = GetComponent<DrillEnergy>();
        SS = FindObjectOfType<SpaceShip>();


        touchingcrystal2 = false;
        touchingcrystal3 = false;



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

        if (Input.GetMouseButton(1) && Input.GetMouseButton(2) && LM.IsthereaDrone == false && DE.OurEnergy == 100)
        {
            Anim.SetBool("isDrilling", false);
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isWalkingRight", false);
            Anim.SetBool("isWalkingLeft", false);
            Anim.SetBool("isWalkingBack", false);
            Anim.SetBool("Shoot", true);
            ReadytoDrill = false;
            movespeed = 0;
         

        }


        if (Input.GetMouseButton(1) && LM.IsthereaDrone == false)
        {
            Anim.SetBool("isDrilling", true);
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isWalkingRight", false);
            Anim.SetBool("isWalkingLeft", false);
            Anim.SetBool("isWalkingBack", false);
            Anim.SetBool("Shoot", false);
            ReadytoDrill = true;
            movespeed = 0;
      


        }

       else if (Input.GetKey(KeyCode.W) && LM.IsthereaDrone == false)
        {
            Anim.SetBool("isWalking", true);
            Anim.SetBool("isDrilling", false);
            Anim.SetBool("isWalkingRight", false);
            Anim.SetBool("isWalkingLeft", false);
            Anim.SetBool("isWalkingBack", false);
            Anim.SetBool("Shoot", false);
            ReadytoDrill = false;
            movespeed = 5;
    



        }

        else if (Input.GetKey(KeyCode.A) && LM.IsthereaDrone == false)
        {
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isDrilling", false);
            Anim.SetBool("isWalkingRight", true);
            Anim.SetBool("isWalkingLeft", false);
            Anim.SetBool("isWalkingBack", false);
            Anim.SetBool("Shoot", false);
            ReadytoDrill = false;
            movespeed = 5;
      

        }

        else if (Input.GetKey(KeyCode.D) &&  LM.IsthereaDrone == false)
        {
            Anim.SetBool("isDrilling", false);
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isWalkingRight", false);
            Anim.SetBool("isWalkingLeft", true);
            Anim.SetBool("isWalkingBack", false);
            Anim.SetBool("Shoot", false);
            ReadytoDrill = false;
            movespeed = 5;
       

        }

        else if (Input.GetKey(KeyCode.S) && LM.IsthereaDrone == false)
        {
            Anim.SetBool("isDrilling", false);
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isWalkingRight", false);
            Anim.SetBool("isWalkingLeft", false);
            Anim.SetBool("isWalkingBack", true);
            Anim.SetBool("Shoot", false);
            ReadytoDrill = false;
            movespeed = 5;
      

        }

        else 
        {
            Anim.SetBool("isDrilling", false);
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isWalkingRight", false);
            Anim.SetBool("isWalkingLeft", false);
            Anim.SetBool("isWalkingBack", false);
            Anim.SetBool("Shoot", false);
            ReadytoDrill = false;
     


        }



        if (LM.IsthereaDrone == true)
        {

            Drone.SetActive(true);
            DroneCanvas.enabled = true;
            movespeed = 0;
            
            Anim.SetBool("isDrilling", false);
            Anim.SetBool("isWalking", false);
            Anim.SetBool("isWalkingRight", false);
            Anim.SetBool("isWalkingLeft", false);
            Anim.SetBool("isWalkingBack", false);
            Anim.SetBool("Shoot", false);
          

        }




        else
        {
            Drone.SetActive(false);
            DroneCanvas.enabled = false;
        }


      


        MovementInputValue = Input.GetAxis(MovementAxisName);
        LeftRightInputValue = Input.GetAxis(LeftRightAxisName);

    }

    private void FixedUpdate()
    {
        if (LM.IsthereaDrone == false)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 movement = transform.forward * MovementInputValue * movespeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        Vector3 LeftRight = transform.right * LeftRightInputValue * movespeed * Time.deltaTime;
        rb.MovePosition(rb.position + LeftRight);

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Crystal")
        {
            touchingCrystal = true;
       
        }

        if (other.gameObject.tag == "Crystal2")
        {
            touchingcrystal2 = true;

        }

        if (other.gameObject.tag == "Crystal3")
        {
            touchingcrystal3 = true;

        }


        if (other.gameObject.tag == "Crystal4")
        {
            touchingcrystal3 = true;

        }

        if (other.gameObject.tag == "Crystal5")
        {
            touchingcrystal3 = true;

        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Crystal2")
        {
            touchingcrystal2 = true;
        }

        if (other.gameObject.tag == "Crystal2")
        {
            touchingCrystal = true;
        }

        if (other.gameObject.tag == "Crystal3")
        {
            touchingcrystal3 = true;

        }

        if (other.gameObject.tag == "Crystal4")
        {
            touchingcrystal3 = true;

        }

        if (other.gameObject.tag == "Crystal5")
        {
            touchingcrystal3 = true;

        }



    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Crystal")
        {
            touchingCrystal = false;
        }
        if (other.gameObject.tag == "Crystal2")
        {
            touchingcrystal2 = false;
        }
        if (other.gameObject.tag == "Crystal3")
        {
            touchingcrystal3 = false;

        }
        if (other.gameObject.tag == "Crystal4")
        {
            touchingcrystal3 = false;

        }

        if (other.gameObject.tag == "Crystal5")
        {
            touchingcrystal3 = false;

        }
    }





}
