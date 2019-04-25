using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody rigidBody;

    void OnTriggerEnter(Collider col) {
        string coltag = col.gameObject.tag;

        if(coltag != "Player" && coltag != "RayGun") {
            gameObject.SetActive(false);
            rigidBody.velocity = new Vector3(0, 0, 0);
        }
    }

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }
}
