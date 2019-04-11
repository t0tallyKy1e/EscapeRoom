using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardScanner : MonoBehaviour {
    public GameObject door;
    public GameObject keyCard;
    public float endZ;
    public float startZ;
    public bool debugOpen;

    private float doorSpeed = 8.0f;
    private float scanCooldownTime = 0.5f;
    private float scanCooldown = 0.0f;
    private bool doorShouldOpen = false;

    void Update() {
        bool doorIsActive = door.activeSelf;
        bool doorIsAtEnd = door.gameObject.transform.position == new Vector3(endZ, door.gameObject.transform.position.y, door.gameObject.transform.position.z);

        if((debugOpen || doorShouldOpen) && !doorIsAtEnd) {
            // https://answers.unity.com/questions/570573/how-do-i-slowly-translate-a-object-to-a-other-obje.html - Vector3.MoveTowards() found here
            float step = doorSpeed * Time.deltaTime;
            door.gameObject.transform.position = Vector3.MoveTowards(door.gameObject.transform.position, new Vector3(door.gameObject.transform.position.x, door.gameObject.transform.position.y, endZ), step);
        } else if((debugOpen || doorShouldOpen) && doorIsAtEnd) {
            door.gameObject.SetActive(!doorIsActive);
        }
    }

	void OnTriggerEnter(Collider col) {
        bool doorIsActive = door.activeSelf;

        if(scanCooldown > 0.0f) {
            scanCooldown -= Time.deltaTime;
        } else {
            scanCooldown = 0.0f;
        }

		if(col.gameObject.tag == keyCard.tag && scanCooldown == 0.0f) {
            doorShouldOpen = true;
            scanCooldown = scanCooldownTime;
		}
	}
}
