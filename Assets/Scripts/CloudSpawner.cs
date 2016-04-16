using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudSpawner : MonoBehaviour {

    public List<GameObject> cloudPrefabs;

    public int density = 10;

	void Start () {
	    for (int i = 0; i < density; i++)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(
                (Random.Range(-(float)Screen.width, (float)Screen.width*2)),
                Random.Range((int)(Screen.height * 0.6), Screen.height*1.5f),
                30));

            newPos.z = -newPos.z;

            GameObject go = (GameObject)Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Count-1)], newPos, 
                Quaternion.identity);

            go.GetComponent<SpriteRenderer>().flipX = Random.Range(0, 2) == 0;

            var scale = Random.Range(3.0f, 4.5f);
            go.transform.localScale = new Vector3(scale, scale, 0);

            go.transform.SetParent(transform);

            StartCoroutine("CloudMoving", go);
        }

        transform.Translate(new Vector3(0,0,33));
	}

    IEnumerator CloudMoving(GameObject go)
    {
        int direction = Random.Range(0, 2) == 0 ? 1 : -1;
        float speed = Random.Range(0.005f, 0.2f);
        while (true)
        {
            go.transform.Translate(new Vector3(direction,0,0) * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }
	
	void Update () {
	    
	}
}
