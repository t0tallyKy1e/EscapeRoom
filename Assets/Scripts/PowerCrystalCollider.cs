﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCrystalCollider : MonoBehaviour {
    public Light light;
    public AudioClip powerUpSound;
    public AudioClip poweredEscapePodSound;

    private AudioSource audioSource;

    void OnTriggerEnter(Collider col) {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(col.gameObject.tag == "Crystal" && !gm.crystalCollected) {
            audioSource.Play();
            gm.SetCrystalStatus(true);
            light.intensity = 1.25f;
        }

        if(gm.crystalCollected && audioSource.clip == powerUpSound && !audioSource.isPlaying) {
            audioSource.clip = poweredEscapePodSound;
            audioSource.loop = true;
            audioSource.volume = .65f;
            audioSource.Play();
        }
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
        light.intensity = 0.0f;
    }
}
