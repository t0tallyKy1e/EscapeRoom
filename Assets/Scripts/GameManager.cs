using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float gravity;
    public AudioClip ambientSounds;
    private AudioSource audioSource;

    // win status
    public bool oxygenTankCollected;
    public bool crystalCollected;
    public bool buttonSequenceIsCorrect;
    public AudioSource correctButtonAudioSource;
    public bool winStatus;
    public AudioSource winSoundSource;
    private int timesToPlayWinSound = 3;

    // post-win escape pod movement
    public GameObject escapePod;
    public float escapePodEndPositionY;
    private float escapePodWorldEndPositionY = -7.77f;
    public GameObject escapePodDoor;
    public float escapePodDoorEndRotationY;
    public GameObject escapePodScanner;

    // post-win time
    private float postWinCooldown;
    public float postWinTime;
    private bool ranWinFunction = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ambientSounds;
        audioSource.time = 10.5f;
        audioSource.Play();
        timesToPlayWinSound = 3;
    }

    void Update() {
        winStatus = CheckWinStatus();

        // check if the player has won
        if(winStatus) {
            // make sure wingame() only runs once
            if(!ranWinFunction) {
                WinGame();
                postWinCooldown = postWinTime;
            }
            
            // quit after a certain number of seconds, otherwise move escape pod towards goal
            if(postWinCooldown <= 0.0f) {
                Debug.Log("Application Quit");
                Application.Quit();
            } else {
                postWinCooldown -= Time.deltaTime;
        
                float step = 8.0f * Time.deltaTime;
                escapePod.transform.position = Vector3.MoveTowards(escapePod.transform.position, new Vector3(37.7f, escapePodEndPositionY, 17.7f), step);
            }
        }
    }

    bool CheckWinStatus() {
        return buttonSequenceIsCorrect && crystalCollected && oxygenTankCollected;
    }

    public void SetButtonSequenceStatus(bool status) {
        buttonSequenceIsCorrect = status;

        if(buttonSequenceIsCorrect) {
            correctButtonAudioSource.Play();
        }
    }

    public void SetCrystalStatus(bool status) {
        crystalCollected = status;
    }

    public void SetOxygenTankStatus(bool status) {
        oxygenTankCollected = status;
    }

    void WinGame() {
        // play alarm noise a few times to indicate a win
        if(timesToPlayWinSound > 0 && !winSoundSource.isPlaying) {
            winSoundSource.Play();
            timesToPlayWinSound--;
        }

        // set everything in place
        Quaternion tempRotation =  escapePodDoor.transform.rotation;
        tempRotation.y = escapePodDoorEndRotationY;
        escapePodDoor.transform.rotation = tempRotation;

        ranWinFunction = true;
    }
}
