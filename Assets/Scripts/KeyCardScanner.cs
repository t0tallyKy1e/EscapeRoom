using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardScanner : MonoBehaviour {
    public GameObject door;
    public GameObject keyCard;

    private float scanCooldownTime = 0.5f;
    private float scanCooldown = 0.0f;

	void OnTriggerEnter(Collider col) {
        bool doorIsActive = door.activeSelf;

        if(scanCooldown > 0.0f) {
            scanCooldown -= Time.deltaTime;
        } else {
            scanCooldown = 0.0f;
        }

		if(col.gameObject.tag == keyCard.tag && scanCooldown == 0.0f) {
            door.gameObject.SetActive(!doorIsActive);
            scanCooldown = scanCooldownTime;
		}
	}
}
