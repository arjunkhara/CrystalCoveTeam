using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveMonsterAnimationScript : MonoBehaviour {

    public Animator Anim;

	void Start () {
        Anim.GetComponent<Animator>();
	}
	

	void Update () {
        if (Input.GetKey(KeyCode.P))
        {
            Anim.SetBool("Hello", true);
            Debug.Log("Hello");
        }

        if (Input.GetKey(KeyCode.L))
        {
            Anim.SetBool("Hello", false);
            Debug.Log("Hello");
        }

    }
}
