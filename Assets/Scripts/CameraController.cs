using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I don't think this script is used and I don't remember writing it.
public class CameraController : MonoBehaviour {
	[SerializeField]
	private bool invert;
	[SerializeField]
	private Transform lookRoot;
	[SerializeField]
	private Transform playerRoot;
	[SerializeField]
	private float sensitivity = 5.0f;
	[SerializeField]
	private Vector2 defaultLookLimits = new Vector2(-70f, 80f); // min, max

	private Vector2 currentCameraLook;
	private Vector2 lookAngles;

	void Update() {
		LookAround();
	}

	void LookAround() {
		currentCameraLook = new Vector2(Input.GetAxis("CameraVertical"), Input.GetAxis("CameraHorizontal"));

		lookAngles.x += currentCameraLook.x * sensitivity * (invert ? 1.0f : -1.0f);
		lookAngles.y += currentCameraLook.y * sensitivity;

		lookAngles.x = Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

		lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0.0f, 0.0f);
		playerRoot.localRotation = Quaternion.Euler(0.0f, lookAngles.y, 0.0f);
	}
}
