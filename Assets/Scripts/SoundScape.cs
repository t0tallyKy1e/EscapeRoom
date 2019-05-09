using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundScape : MonoBehaviour {
    public AudioSource whooshSource;
    public AudioSource transmissionSource;
    public AudioSource alienBreathingSource;
    public AudioSource bubblingCauldronSource;
    public AudioSource oxygenBeepsSource;
    
    public float cooldownTime;
    public float beepCooldownTime;

    void Start() {
        beepCooldownTime = 1.5f;
    }

    // this is a colection of sounds to play when player is being abducted
    void Update() {
        cooldownTime -= Time.deltaTime;
        beepCooldownTime -= Time.deltaTime;

        if(!whooshSource.isPlaying) {
            if(!transmissionSource.isPlaying) {
                transmissionSource.Play();
            }

            if(!alienBreathingSource.isPlaying) {
                alienBreathingSource.Play();
            }
            
            if(!bubblingCauldronSource.isPlaying) {
                bubblingCauldronSource.Play();
            }

            if(!oxygenBeepsSource.isPlaying && beepCooldownTime <= 0.0f) {
                oxygenBeepsSource.Play();
                beepCooldownTime = 2.15f;
            }
        }

        if(cooldownTime <= 0.0f) {
            SceneManager.LoadScene("ShipScene");
        } else if(cooldownTime <= 1.202f) {
            if(!whooshSource.isPlaying) {
                whooshSource.Play();
            }
        }
    }
}
