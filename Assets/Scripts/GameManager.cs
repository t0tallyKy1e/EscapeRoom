using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float gravity;
    public AudioClip ambientSounds;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ambientSounds;
        audioSource.Play();
    }
}
