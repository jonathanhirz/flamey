using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameyControls : MonoBehaviour {

	public float rotationSpeed = 0.2f;
	public float speed = 10;
	public Transform head;
	public float minHeadRotation = -30.0f;
	public float maxHeadRotation = 30.0f;
	public float jumpSpeed = 15.0f;
	public float gravity = 30.0f;

	Rigidbody rb2d;
	CharacterController controller;
	float currentHeadRotation = 0.0f;
	float yVelocity = 0.0f;
	
	void Awake() {
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update() {

		// movement input
		Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
		// rotate player + camera side to side
		transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);

		// rotate camera up and down
		currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);
		head.localRotation = Quaternion.identity;
		head.Rotate(Vector3.left, currentHeadRotation);

		if(controller.isGrounded) {
			yVelocity = 0;
			// jump input
			if(Input.GetButtonDown("Jump")) {
				yVelocity = jumpSpeed;
			}
		}

		// apply gravity
		yVelocity -= gravity * Time.deltaTime;

		// move player
		controller.Move(transform.TransformDirection(input * speed * Time.deltaTime + yVelocity * Vector3.up * Time.deltaTime));

	}
}
