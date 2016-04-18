using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {
    public float maxScale = 1.2f;
	void Start () {
        GetComponent<SpriteRenderer>().flipX = Random.Range(0, 2) == 0;
        transform.localScale = transform.localScale * Random.Range(0.8f, maxScale);
    }
}
