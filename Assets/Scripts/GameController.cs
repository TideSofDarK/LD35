using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public AudioClip rain_clip;

    public GameObject door;

    public GameObject character;

    public GameObject rain;

    public GameObject window;

    public GameObject thunder;

    public GameObject apc;

    public GameObject[] cameraPoints;
    protected int currentPoint = 0;

    public static bool firstTime = false;

	// Use this for initialization
	void Start () {
        if (!GameController.firstTime)
        {
            DontDestroyOnLoad(GameObject.FindWithTag("RainSound"));
            DontDestroyOnLoad(GameObject.FindWithTag("WindSound"));

            GameController.firstTime = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void StartWindowAnimation()
    {
        window.GetComponent<Animator>().enabled = true;
        thunder.GetComponent<Thunder>().Invoke("Init", 4.4f);
        StartCoroutine("PlayRain");
    }

    public void StartCamera()
    {
        //Camera.main.transform.DOMove(cameraPoints[currentPoint].transform.position, 3f, true).OnComplete(StartWindowAnimation);
        StartWindowAnimation();
        currentPoint++;
    }

    IEnumerator PlayRain()
    {
        yield return new WaitForSeconds(6.3f);
        AudioSource audio = GameObject.FindWithTag("RainSound").GetComponent<AudioSource>();
        var volume = audio.volume;

        audio.volume = 0f;
            
        audio.Play();

        apc.GetComponent<Image>().DOFade(1f, 1.5f).SetDelay(1.1f);
        apc.GetComponent<Image>().DOFade(0f, 1.5f).SetDelay(6.1f);
        Invoke("NextScene", 8f);

        rain.SetActive(true);

        while (audio.volume < volume)
        {
            audio.volume = audio.volume + (Time.deltaTime / 10);
            yield return new WaitForEndOfFrame();
        }
    }

    public void NextScene()
    {
        var pixelater = new PixelateTransition()
        {
            nextScene = 1,
            finalScaleEffect = PixelateTransition.PixelateFinalScaleEffect.ToPoint,
            duration = 1.0f
        };
        TransitionKit.instance.transitionWithDelegate(pixelater);
    }
}
