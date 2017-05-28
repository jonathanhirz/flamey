using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour {

	void Start() {
		Cursor.visible = false;
	}

	void Update() {
		if(Input.GetKey("escape")) {
			Application.Quit();
		}
	}
}
