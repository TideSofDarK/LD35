using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

    public List<Texture2D> variants;

    void Start () {
        GetComponent<Renderer>().material.mainTexture = (variants[Random.Range(0, variants.Count)]);
        GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("_Glossiness"), 0.65f - 
            (Mathf.Abs(Camera.main.transform.position.z - transform.position.z) / 80f)); 
        transform.Translate(new Vector3(0,Random.Range(-0.1f, 0f),0));
    }

	void Update () {
	
	}
}
