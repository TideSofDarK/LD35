using UnityEngine;
using System.Collections;

public class Fence : MonoBehaviour {

    public GameObject fencePrefab;

    public int count = 10;

    private Sprite[] fences;

	// Use this for initialization
	void Start () {
        fences = new Sprite[(count*2) + 1];
        fences[0] = GetComponent<Sprite>();

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

        for (int i = 1; i < count * 2; i++)
        {
            int mod = i > count ? (i - count) * -1 : i;
            GameObject go = (GameObject)Instantiate(fencePrefab, new Vector3(spriteSize.x * mod, 0,0) + transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            fences[i] = go.GetComponent<Sprite>();
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
