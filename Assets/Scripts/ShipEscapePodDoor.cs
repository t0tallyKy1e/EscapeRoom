using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEscapePodDoor : MonoBehaviour {
    public bool isOpen;
    public bool unlocked;
    public float maxXPosition;
    public float minXPosition;
    public float maxZPosition;
    public float minZPosition;
    public float doorSpeed;

    void Open() {
        float step = doorSpeed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(maxXPosition, gameObject.transform.position.y, maxZPosition), step);
    }

    public void Unlock() {
        unlocked = true;
    }

    void Update() {
        // if door is unlocked, open it
        if(unlocked && !isOpen) {
            Open();
        } else if(unlocked && !isOpen && ((minZPosition < maxZPosition && gameObject.transform.position.y <= maxZPosition) || (minZPosition > maxZPosition && gameObject.transform.position.y >= maxZPosition))) {
            isOpen = true;
        } else if(isOpen) {
            // Debug.Log("deactivate");
            gameObject.SetActive(!gameObject.activeSelf); // deactivate door
        }
    }
}
