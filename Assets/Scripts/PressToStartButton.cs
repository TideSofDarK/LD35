using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PressToStartButton : MonoBehaviour {

    private Text textComponent;
    private bool pressed = false;

	void Start () {
        textComponent = GetComponent<Text>();

        textComponent.DOFade(1f, 1.2f).SetDelay(0.6f);
    }
	
	void Update () {
        if (!pressed && Time.time > 2.5f)
        {
            if (Input.anyKey)
            {
                pressed = true;
                textComponent.CrossFadeAlpha(0f, 0.6f, false);
                textComponent.DOFade(0f, 0.8f).SetEase(Ease.InOutBounce);

                GameObject.FindWithTag("Bell").GetComponent<AudioSource>().Play();

                Invoke("StartCamera", 1.1f);
            }
            else
            {
                var color = textComponent.color;
                color.a = Mathf.Lerp(color.a, Mathf.Abs(Mathf.Cos(Time.time)), Time.deltaTime);
                textComponent.color = color;
            }
        }
    }

    void StartCamera()
    {
        GameObject.FindWithTag("GameController").SendMessage("StartCamera");
    }
}
