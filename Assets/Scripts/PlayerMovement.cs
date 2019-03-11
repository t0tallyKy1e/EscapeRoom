using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5f;

	private CharacterController characterController;
	private GameManager gameManager;
	private Vector3 moveDirection;

	void Awake () {
		characterController = GetComponent<CharacterController>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), gameManager.gravity, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection) * speed * Time.deltaTime;

		characterController.Move(moveDirection);
	}
}
