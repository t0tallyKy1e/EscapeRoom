using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public bool power; // 0 = off ... 1 = on
    public float offIntensity;
    public float onIntensity;

    public Light light;
    private float inputCooldown = 0.0f;
    private float cooldownTime = .5f;
    private bool isGrabbed;
    
    void Start() {
        TurnOn();
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;
    }
    
    void Update() {
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;

        if(inputCooldown > 0.0f) {
            inputCooldown -= Time.deltaTime;
        } else {
            inputCooldown = 0.0f;
        }

        if(isGrabbed && (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two))) {
            if(power) {
                if(inputCooldown == 0.0f) {
                    TurnOff();
                    inputCooldown = cooldownTime;
                }
            } else {
                if(inputCooldown == 0.0f) {
                    TurnOn();
                    inputCooldown = cooldownTime;
                }
            }
        }
    }

    void TurnOff() {
        power = false;
        light.enabled = !light.enabled;
    }

    void TurnOn() {
        power = true;
        light.enabled = !light.enabled;
    }
}
