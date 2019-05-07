using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCrystalCollider : MonoBehaviour {
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Crystal") {
            GameObject.Find("GameManager").GetComponent<GameManager>().SetCrystalStatus(true);
        }
    }
}
