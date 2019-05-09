using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePodLeverHandle : MonoBehaviour {
    public float offRotation;
    public float onRotation;
    public GameObject door;
    public bool debug;

    // unlock door if handle is moved - this script is not used asfar as I know
    void Update() {
        if(debug || transform.rotation.z >= onRotation) {
            door.GetComponent<ShipEscapePodDoor>().Unlock();
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
