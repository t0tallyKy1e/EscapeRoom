using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private CharacterController characterController;
	private Vector3 moveDirection;

	public float speed = 5f;

	void Awake () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection) * speed * Time.deltaTime;

		characterController.Move(moveDirection);
	}
}
