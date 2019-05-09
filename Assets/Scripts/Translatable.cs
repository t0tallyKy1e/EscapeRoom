using UnityEngine;

public class Translatable : MonoBehaviour
{
    public Sprite alienPoster;
    public Sprite earthPoster;
    public GameObject child;

    // script used to change sprite on posters, based on whether or not translator is pointing at it
    void Start() {
        child.GetComponent<SpriteRenderer>().sprite = alienPoster;
    }

    public void TranslateToAlien() {
        child.GetComponent<SpriteRenderer>().sprite = alienPoster;
    }

    public void TranslateToEarth() {
        child.GetComponent<SpriteRenderer>().sprite = earthPoster;
    }
}
