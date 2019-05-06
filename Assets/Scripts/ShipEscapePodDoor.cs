using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEscapePodDoor : MonoBehaviour {
    public bool isOpen;
    public bool unlocked;
    public float maxZPosition;
    public float minZPosition;
    public float doorSpeed;

    void Open() {
        float step = doorSpeed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, maxZPosition), step);
    }

    public void Unlock() {
        unlocked = true;
    }

    void Update() {

        Debug.Log(transform.position.z);

        if(unlocked && !isOpen) {
            Open();
        } else if(unlocked && !isOpen && ((minZPosition < maxZPosition && gameObject.transform.position.y <= maxZPosition) || (minZPosition > maxZPosition && gameObject.transform.position.y >= maxZPosition))) {
            isOpen = true;
        } else if(isOpen) {
            Debug.Log("deactivate");
            gameObject.SetActive(!gameObject.activeSelf); // deactivate door
        }
    }
}
