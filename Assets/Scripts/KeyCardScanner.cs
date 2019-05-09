using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardScanner : MonoBehaviour {
    public GameObject door;
    public GameObject keyCard;
    public GameObject closedScreen;
    public GameObject openScreen;
    public string acceptedKeyCardType;

    public float endZ;
    public float startZ;
    public Transform endPosition;
    public bool debugOpen;

    private float doorSpeed = 4.0f;
    private float scanCooldownTime = 0.5f;
    private float scanCooldown = 0.0f;
    private bool doorShouldOpen = false;
    private AudioSource audioSource;

    void Start() {
        // set correct screen type
        if(closedScreen != null) {
            closedScreen.gameObject.SetActive(true);
            openScreen.gameObject.SetActive(false);
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        bool doorIsActive = door.activeSelf;
        bool doorIsAtEnd = door.gameObject.transform.position == new Vector3(endZ, door.gameObject.transform.position.y, door.gameObject.transform.position.z);

        // move door if opened
        if((debugOpen || doorShouldOpen) && !doorIsAtEnd) {
            // https://answers.unity.com/questions/570573/how-do-i-slowly-translate-a-object-to-a-other-obje.html - Vector3.MoveTowards() found here
            float step = doorSpeed * Time.deltaTime;

            if(Mathf.Approximately(endZ, 0)) {
                door.gameObject.transform.position = Vector3.MoveTowards(door.gameObject.transform.position, endPosition.position, step);
            } else {
                door.gameObject.transform.position = Vector3.MoveTowards(door.gameObject.transform.position, new Vector3(door.gameObject.transform.position.x, door.gameObject.transform.position.y, endZ), step);
            }
        } else if((debugOpen || doorShouldOpen) && doorIsAtEnd) {
            door.gameObject.SetActive(false);
        } else if(door.gameObject.transform.position.z >= endZ) {
            doorIsAtEnd = true;
        } 
        
        if(debugOpen) {
            // Debug.Log(door.gameObject.transform.position.z);
        }
    }

	void OnTriggerEnter(Collider col) {
        bool doorIsActive = door.activeSelf;

        // only allow player to scan every few seconds
        if(scanCooldown > 0.0f) {
            scanCooldown -= Time.deltaTime;
        } else {
            scanCooldown = 0.0f;
        }

        string collidedKeyCardType = "";
        KeyCard tempKeyCard = col.gameObject.GetComponent<KeyCard>();

        // make sure the key card has a type
        if(tempKeyCard != null) {
            collidedKeyCardType = col.gameObject.GetComponent<KeyCard>().type;
        } else {
            collidedKeyCardType = null;
        }

        // if key card is the right kind, open door
		if(collidedKeyCardType != null && collidedKeyCardType == acceptedKeyCardType && col.gameObject.tag == keyCard.tag && scanCooldown == 0.0f) {
            Open();
		}
	}

    // open attached door
    public void Open() {
        audioSource.Play();
        doorShouldOpen = true;
        scanCooldown = scanCooldownTime;
        if(closedScreen != null) {
            closedScreen.gameObject.SetActive(false);
            openScreen.gameObject.SetActive(true);
        }
    }
}
