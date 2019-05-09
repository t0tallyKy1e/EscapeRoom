using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I don't think this script is used and I don't remember writing it.
public class PlayerMovement : MonoBehaviour {
	public float speed = 5f;

	private CharacterController characterController;
	private GameManager gameManager;
	private Vector3 moveDirection;

	void Awake () {
		characterController = GetComponent<CharacterController>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
		Move();
	}

	void Move() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), gameManager.gravity, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection) * speed * Time.deltaTime;

		characterController.Move(moveDirection);
	}
}
