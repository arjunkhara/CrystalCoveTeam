using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterPatrol))]
public class EnemyChase : MonoBehaviour
{

    public Transform player;
  
    public float playerDistance;
    public float HologramDistance;
    public float rotationDampling;
    public float moveSpeed;
    public float lookDistance;
    public float chaseDistance;
    public float stopChaseDistance;

    MonsterPatrol MP;
    public Transform SpawnPoint;
    bool AtStartingPosition;
    public GameObject Enemy;

    Hologram HGM;

    public Animator PassiveEnemyAnimator;




    private void Start()
    {
        MP = GetComponent<MonsterPatrol>();
        Enemy.transform.position = SpawnPoint.transform.position;
 
        PassiveEnemyAnimator = GetComponent<Animator>();


    }

    void Update()
    {

     
        if (Enemy.transform.position == SpawnPoint.transform.position)
        {
            MP.enabled = false;
  
         }


        playerDistance = Vector3.Distance(player.position, transform.position);
      


       


        if (playerDistance < lookDistance)
        {
            lookAtPlayer();
    
        }

        if (playerDistance < chaseDistance)
        {
            chase();
           
        }

        if (playerDistance > stopChaseDistance && Enemy.transform.position != SpawnPoint.transform.position)
        {
            MP.enabled = true;
            PassiveEnemyAnimator.SetBool("IsItIdle", true);
            PassiveEnemyAnimator.SetBool("IsItWalking", false);
            PassiveEnemyAnimator.SetBool("IsItInRange", false);
        }




    }

    void lookAtPlayer()
    {

        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);
        PassiveEnemyAnimator.SetBool("IsItIdle", true);
        PassiveEnemyAnimator.SetBool("IsItWalking", false);
        PassiveEnemyAnimator.SetBool("IsItInRange", false);
    }


   


    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        PassiveEnemyAnimator.SetBool("IsItIdle", false);
        PassiveEnemyAnimator.SetBool("IsItWalking", true);
        PassiveEnemyAnimator.SetBool("IsItInRange", false);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PassiveEnemyAnimator.SetBool("IsItInRange", true);
            PassiveEnemyAnimator.SetBool("IsItIdle", false);
            PassiveEnemyAnimator.SetBool("IsItWalking", false);
        }
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PassiveEnemyAnimator.SetBool("IsItInRange", true);
            PassiveEnemyAnimator.SetBool("IsItIdle", false);
            PassiveEnemyAnimator.SetBool("IsItWalking", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PassiveEnemyAnimator.SetBool("IsItInRange", false);
            PassiveEnemyAnimator.SetBool("IsItIdle", false);
            PassiveEnemyAnimator.SetBool("IsItWalking", true);
        }
    }
}

