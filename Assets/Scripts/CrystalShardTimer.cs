using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShardTimer : MonoBehaviour {

	public float lifeTime;


	void Update () {

		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0)
			Destroy (gameObject);
		
	}
}
