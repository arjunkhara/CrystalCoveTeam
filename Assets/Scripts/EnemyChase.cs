using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterPatrol))]
public class EnemyChase : MonoBehaviour
{

    public Transform player;
    public Transform Hologram;
  
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
        HGM = FindObjectOfType<Hologram>();
        PassiveEnemyAnimator = GetComponent<Animator>();


    }

    void Update()
    {

     
        if (Enemy.transform.position == SpawnPoint.transform.position)
        {
            MP.enabled = false;
  
         }


        playerDistance = Vector3.Distance(player.position, transform.position);
        HologramDistance = Vector3.Distance(Hologram.position, transform.position);


        if(HologramDistance < lookDistance && HGM.HoloisOn == true)
        {
            LookatHologram();
     
        }


        if (playerDistance < lookDistance && HGM.HoloisOn == false)
        {
            lookAtPlayer();
    
        }

        if (playerDistance < chaseDistance && HGM.HoloisOn == false || HologramDistance < chaseDistance && HGM.HoloisOn == false)
        {
            chase();
           
        }

        if (playerDistance > stopChaseDistance && Enemy.transform.position != SpawnPoint.transform.position || HologramDistance > stopChaseDistance && Enemy.transform.position != SpawnPoint.transform.position)
        {
            MP.enabled = true;
        }

    }

    void lookAtPlayer()
    {

        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);
        PassiveEnemyAnimator.SetBool("IsItIdle", true);
        PassiveEnemyAnimator.SetBool("IsItWalking", false);
    }


    void LookatHologram()
    {
        Quaternion rotation = Quaternion.LookRotation(Hologram.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);
        PassiveEnemyAnimator.SetBool("IsItIdle", true);
        PassiveEnemyAnimator.SetBool("IsItWalking", false);
    }



    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        PassiveEnemyAnimator.SetBool("IsItIdle", false);
        PassiveEnemyAnimator.SetBool("IsItWalking", true);


    }
}

