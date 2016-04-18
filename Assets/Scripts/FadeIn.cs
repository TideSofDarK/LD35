using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Image>().DOFade(0f, 2.5f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
