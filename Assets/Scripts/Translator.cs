using UnityEngine;

public class Translator : MonoBehaviour {
    public Flashlight flashlight;
    public float radius; // for multiple raycasts

    private GameObject lastPosterTranslated = null;

    void Update() {
        // Debug.DrawRay(flashlight.transform.position, flashlight.transform.up, Color.white, 1, false);

        if(flashlight.power) {
            RaycastHit hit;
            bool hitObject = Physics.Raycast(flashlight.transform.position, flashlight.transform.up, out hit);

            // check if an object is hit
            if(hitObject) {
                // Debug.Log(hit.transform.name);

                // if it's translatable, translate it
                if(hit.transform.tag == "Translatable") {
                    lastPosterTranslated = hit.transform.gameObject;
                    hit.transform.gameObject.GetComponent<Translatable>().TranslateToEarth();
                } else if (hit.transform.tag == "KeyCard") {
                    lastPosterTranslated = hit.transform.GetChild(0).gameObject;
                    hit.transform.GetChild(0).gameObject.GetComponent<Translatable>().TranslateToEarth();
                } else {
                    if(lastPosterTranslated != null) {
                        lastPosterTranslated.GetComponent<Translatable>().TranslateToAlien();
                    }
                }
            }
        }
    }
}
