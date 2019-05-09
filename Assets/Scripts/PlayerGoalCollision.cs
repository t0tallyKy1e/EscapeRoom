using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoalCollision : MonoBehaviour {
	public GameObject timer;

	// stop timer if player reached goal
	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Goal") {
			timer.GetComponent<Timer>().Stop();
		}
	}
}
