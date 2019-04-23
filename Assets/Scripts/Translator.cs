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
                Debug.DrawRay(flashlight.transform.position, flashlight.transform.up, Color.white, 2);

                if(hit.transform.tag == "Translatable") {
                    lastPosterTranslated = hit.transform.gameObject;
                    hit.transform.gameObject.GetComponent<Translatable>().TranslateToEarth();
                } else {
                    if(lastPosterTranslated != null) {
                        lastPosterTranslated.GetComponent<Translatable>().TranslateToAlien();
                    }
                }
            }
        }
    }
}
