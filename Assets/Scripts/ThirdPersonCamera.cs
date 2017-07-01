using System.Collections;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	public float mouseSensitivity = 5;
	public Transform target;
	public float distanceFromTarget = 2;
	public Vector2 pitchMinMax = new Vector2(-30, 50);

	public float rotationSmoothTime = 0.12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	void LateUpdate () {
		yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;
		transform.position = target.position - transform.forward * distanceFromTarget;
	}
}
