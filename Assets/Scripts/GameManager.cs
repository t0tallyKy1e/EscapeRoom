using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float gravity;
    public AudioClip ambientSounds;

    private AudioSource audioSource;

    public bool oxygenTankCollected;
    public bool crystalCollected;
    public bool buttonSequenceIsCorrect;
    public bool winStatus;

    public GameObject escapePod;
    public float escapePodEndPositionY;
    private float escapePodWorldEndPositionY = -7.77f;

    public GameObject escapePodDoor;
    public float escapePodDoorEndRotationY;

    public GameObject escapePodScanner;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ambientSounds;
        audioSource.Play();
    }

    void Update() {
        winStatus = CheckWinStatus();

        if(winStatus) {
            WinGame();
        }
    }

    bool CheckWinStatus() {
        return buttonSequenceIsCorrect && crystalCollected && oxygenTankCollected;
    }

    public void SetButtonSequenceStatus(bool status) {
        buttonSequenceIsCorrect = status;
    }

    public void SetCrystalStatus(bool status) {
        crystalCollected = status;
    }

    public void SetOxygenTankStatus(bool status) {
        oxygenTankCollected = status;
    }

    void WinGame() {
        escapePodScanner.GetComponent<AudioSource>().Play();
        
        float step = 8.0f * Time.deltaTime;
        escapePod.transform.position = Vector3.MoveTowards(escapePod.transform.position, new Vector3(37.7f, escapePodEndPositionY, 17.7f), step);

        Quaternion tempRotation =  escapePodDoor.transform.rotation;
        tempRotation.y = escapePodDoorEndRotationY;
        escapePodDoor.transform.rotation = tempRotation;
    }
}
