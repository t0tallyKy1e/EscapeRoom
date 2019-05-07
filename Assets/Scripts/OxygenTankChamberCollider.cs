using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankChamberCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "OxygenTank") {
            GameObject.Find("GameManager").GetComponent<GameManager>().SetOxygenTankStatus(true);
        }
    }
}
