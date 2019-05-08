using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePodButton : MonoBehaviour {
    public int number;
    private AudioSource audioSource;
    
    void OnTriggerEnter(Collider col) {
        audioSource.Play();
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
}
