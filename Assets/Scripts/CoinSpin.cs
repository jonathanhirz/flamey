using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour {

	public float rotate_speed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(rotate_speed * Time.deltaTime, 0, 0));
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	}
	
}
