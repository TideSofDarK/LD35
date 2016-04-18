using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform character;
    private float offset;

	// Use this for initialization
	void Start () {
        offset = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, character.position.x + offset, Time.deltaTime * 4f);
        transform.position = pos;

    }
}
