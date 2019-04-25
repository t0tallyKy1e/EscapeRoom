using UnityEngine;

public class Translatable : MonoBehaviour
{
    public Sprite alienPoster;
    public Sprite earthPoster;
    public GameObject child;

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
