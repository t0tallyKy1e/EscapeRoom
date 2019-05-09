using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankChamberCollider : MonoBehaviour {
    // play sound, set status if oxygen tank is in the correct spot
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "OxygenTank") {
            GetComponent<AudioSource>().Play();
            GameObject.Find("GameManager").GetComponent<GameManager>().SetOxygenTankStatus(true);
        }
    }
}
