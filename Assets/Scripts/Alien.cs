using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    public GameObject targetPosition;
    public GameObject flashlight;
    public GameObject keycard;
    public float alienSpeed;

    public AudioClip bodyFallSoundClip;
    public AudioClip stuffDropSound;

    private float adjustPlayerPositionTime;
    private float timeToEnd = 7.0f;
    private bool initialPositionSet = false;
    private AudioSource audioSource;
    private bool fallSoundHasPlayed = false;

    // check if alien is next to KeyCardScanner #3, drop flashlight and keycard
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "AlienTrigger") {
            flashlight.SetActive(true);
            keycard.SetActive(true);
            audioSource.clip = stuffDropSound;
            audioSource.Play();

            GameObject.Find("KeyCardScannerCollider_03").GetComponent<KeyCardScanner>().Open();
        }
    }

    void Start() {
        flashlight.SetActive(false);
        keycard.SetActive(false);

        adjustPlayerPositionTime = .5f;
        timeToEnd = 7.0f;

        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        float step = alienSpeed * Time.deltaTime;

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, step);

        // allow the player to move after alien is deactivated
        if(gameObject.transform.position == targetPosition.transform.position) {
            gameObject.SetActive(false);
            GameObject.Find("VRPlayer").GetComponent<OVRPlayerController>().playerCanMove = true;
        }

        // timer to play sound when alien falls
        if(timeToEnd > 0.0f) {
            timeToEnd -= Time.deltaTime;

            if(timeToEnd <= 3.15f && !fallSoundHasPlayed) {
                if(!audioSource.isPlaying) {
                    audioSource.clip = bodyFallSoundClip;
                    audioSource.Play();
                    fallSoundHasPlayed = true;
                }
            }
        } else {
            timeToEnd = 0.0f;
        }

        // adjust player to correct height before they are frozen for opening "cutscene"
        if(adjustPlayerPositionTime > 0.0f) {
            adjustPlayerPositionTime -= Time.deltaTime;
        } else {
            if(!initialPositionSet) {
                adjustPlayerPositionTime = 0.0f;
                GameObject.Find("VRPlayer").GetComponent<OVRPlayerController>().playerCanMove = false;
                initialPositionSet = true;
            }
        }
    }
}
