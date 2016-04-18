using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Thunder : MonoBehaviour {

    private Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}

    public void Init()
    {
        StartCoroutine("Blink");
    }

    public void ThunderSound()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Blink()
    {
        var t = Time.time;
        var c = image.color;
        while (Time.time - t < 0.45f)
        {
            c.a = image.color.a == 1f ? 0.0f : 1f;
            image.color = c;
            yield return new WaitForSeconds(0.2f);
        }
        c.a = 0f;
        image.color = c;
        Invoke("ThunderSound", 0.1f);
    }
}
