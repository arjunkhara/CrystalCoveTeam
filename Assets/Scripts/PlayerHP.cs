using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour {

    public int count;

    public GameObject Sparks;
    public GameObject Smoke;
    public GameObject Fire;
    public GameObject Explosion;

    SpaceShip SS;
    PlayerController PC;
    MouseLook ML;
    LevelManager LM;
    Drill Drill;

    public float Timer;


	void Start () {
        count = 0;
        Sparks.SetActive(false);
        Smoke.SetActive(false);
        Fire.SetActive(false);
        Explosion.SetActive(false);
        Timer = 0;
        SS = FindObjectOfType<SpaceShip>();
        PC = GetComponent<PlayerController>();
        ML = GetComponent<MouseLook>();
        LM = GetComponent<LevelManager>();
        Drill = GetComponent<Drill>();
	}
	
	void Update () {
        if(count == 1)
        {
            Sparks.SetActive(true);
        }

        if(count == 2)
        {
            Smoke.SetActive(true);
        }

        if(count == 3)
        {
            Fire.SetActive(true);
        }
        if (count >= 4)
        {
            Explosion.SetActive(true);
            LM.enabled = false;
            PC.enabled = false;
            SS.enabled = false;
            ML.enabled = false;
            Drill.enabled = false;
            Timer += 1 * Time.deltaTime;


        }

        if(Timer >= 3)
        {
            SceneManager.LoadScene("Level 1");
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            count += 1;
        } 
    }
}
