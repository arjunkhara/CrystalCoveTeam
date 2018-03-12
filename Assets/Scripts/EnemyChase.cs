using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterPatrol))]
public class EnemyChase : MonoBehaviour
{

    public Transform player;
    public float playerDistance;
    public float rotationDampling;
    public float moveSpeed;
    public float lookDistance;
    public float chaseDistance;
    public float stopChaseDistance;
    MonsterPatrol MP;
    public Transform SpawnPoint;

    bool AtStartingPosition;

    public GameObject Enemy;


    public Transform Hologram;
    public float HologramDistance;
    Hologram HSA;



    private void Start()
    {
        MP = GetComponent<MonsterPatrol>();
        Enemy.transform.position = SpawnPoint.transform.position;
        HSA = FindObjectOfType<Hologram>();
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



        if (HologramDistance < lookDistance && HSA.ison == true)
        {
            lookAtHologram();
        }


        if (playerDistance < chaseDistance)
        {

            chase();
        }

        if (playerDistance > stopChaseDistance && Enemy.transform.position != SpawnPoint.transform.position)
        {
            MP.enabled = true;
        }

        if (HologramDistance < chaseDistance && HSA.ison == true)
        {
            chase();
            MP.enabled = false;
        }



        if (HologramDistance > stopChaseDistance)
        {
            MP.enabled = true;
        }

    }

    void lookAtPlayer()
    {

        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);
    }

    void lookAtHologram()
    {

        Quaternion rotation = Quaternion.LookRotation(Hologram.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);
    }

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}

