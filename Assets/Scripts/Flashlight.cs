using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public Light light;
    public bool power; // 0 = off ... 1 = on
    public float offIntensity;
    public float onIntensity;

    private float inputCooldown = 0.0f;
    private float cooldownTime = .5f;
    private bool isGrabbed;
    private AudioSource audioSource;
    
    void Start() {
        TurnOn();
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update() {
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;

        // delay button press after pressing button
        if(inputCooldown > 0.0f) {
            inputCooldown -= Time.deltaTime;
        } else {
            inputCooldown = 0.0f;
        }

        // if the flashlight is grabbed and the button is pressed, turn on / off
        if(isGrabbed && (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two))) {
            if(power) {
                if(inputCooldown == 0.0f) {
                    audioSource.Play();
                    TurnOff();
                    inputCooldown = cooldownTime;
                }
            } else {
                if(inputCooldown == 0.0f) {
                    audioSource.Play();
                    TurnOn();
                    inputCooldown = cooldownTime;
                }
            }
        }
    }

    void TurnOff() {
        power = false;
        light.intensity = offIntensity;
    }

    void TurnOn() {
        power = true;
        light.intensity = onIntensity;
    }
}
