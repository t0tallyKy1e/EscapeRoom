using UnityEngine;

public class Translator : MonoBehaviour {
    public Flashlight flashlight;
    public float radius;

    private GameObject lastPosterTranslated = null;

    void Update() {
        RaycastHit hit;
        if(flashlight.power) {
            bool hitObject = Physics.Raycast(flashlight.transform.position, flashlight.transform.up, out hit);

            if(hitObject) {
                // Debug.Log(hit.transform.name);

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
