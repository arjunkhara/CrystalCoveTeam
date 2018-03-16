using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MonsterPatrol))]
public class AggressiveEnemyChase : MonoBehaviour {


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

    Hologram HGM;

    private void Start()
    {
        MP = GetComponent<MonsterPatrol>();
        HGM = FindObjectOfType<Hologram>();
    }

    void Update()
    {

        playerDistance = Vector3.Distance(player.position, transform.position);


        if (playerDistance < lookDistance && HGM.HoloisOn == false || HologramDistance < lookDistance && HGM.HoloisOn == true)
        {

            chase();
            MP.enabled = false;
        }

        if (playerDistance > stopChaseDistance && HGM.HoloisOn == false)
        {
            MP.enabled = true;
        }

    }

    

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}
