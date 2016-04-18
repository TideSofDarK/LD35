using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    void Setup()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
