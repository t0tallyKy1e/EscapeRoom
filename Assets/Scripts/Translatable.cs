using UnityEngine;

public class Translatable : MonoBehaviour
{
    public Material alienPoster;
    public Material earthPoster;

    void Start() {
        gameObject.GetComponent<Renderer>().material = alienPoster;
    }

    public void TranslateToAlien() {
        gameObject.GetComponent<Renderer>().material = alienPoster;
    }

    public void TranslateToEarth() {
        gameObject.GetComponent<Renderer>().material = earthPoster;
    }
}
