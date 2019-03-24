using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    void OnTriggerEnter(Collider col) {
        string coltag = col.gameObject.tag;

        if(coltag != "Player" && coltag != "RayGun") {
            gameObject.SetActive(false);
        }
    }
}
