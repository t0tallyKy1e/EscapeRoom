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

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ambientSounds;
        audioSource.Play();
    }

    void Update() {
        winStatus = CheckWinStatus();

        if(winStatus) {
            Debug.Log("Player wins game.");
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
}
