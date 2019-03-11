using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoalCollision : MonoBehaviour {
	public GameObject timer;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Goal") {
			timer.GetComponent<Timer>().Stop();
		}
	}
}
