﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour {
    public GameObject bullet;
    public float fireSpeed;
    public float fireRate;
    public int magazineSize;
    
    public Transform bulletOffset;

    private GameObject[] magazine;
    private bool isGrabbed;
    private int currentBullet;

    private float fireRateTime;
    
    void Start() {
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;

        magazine = new GameObject[magazineSize];

        PopulateMagazine();

        for(int i = 0; i < magazineSize; i++) {
            magazine[i].SetActive(false);
        }

        currentBullet = 0;
    }
    
    void Update() {
        isGrabbed = GetComponent<OVRGrabbable>().isGrabbed;

        if(isGrabbed && Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0 && currentBullet < magazineSize && fireRateTime == 0.0f) {
            Shoot();
        }

        if(fireRateTime > 0.0f) {
            fireRateTime -= Time.deltaTime;
        } else {
            fireRateTime = 0.0f;
        }
    }

    void Shoot() {
        magazine[currentBullet].transform.position = transform.position + bulletOffset.position;
        magazine[currentBullet].transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        magazine[currentBullet].SetActive(true);
        magazine[currentBullet].GetComponent<Rigidbody>().AddForce(-transform.forward * fireSpeed);

        fireRateTime = fireRate;
        currentBullet++;

        // start back at the beginning if there are no bullets left
        if(currentBullet == magazineSize) {
            currentBullet = 0;
        }
    }

    void PopulateMagazine() {
        for(int i = 0; i < magazineSize; i++) {
            magazine[i] = Instantiate(bullet);
            magazine[i].transform.position = transform.position;
            magazine[i].transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
