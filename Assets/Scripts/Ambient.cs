using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ambient : MonoBehaviour {

    public AudioClip[] clips;
    public List<int> usedClips = new List<int>();

	// Use this for initialization
	void Start () {
        Invoke("PlayRandomSound", 19f);
    }

    void PlayRandomSound()
    {
        int newClip = 0;
        do
        {
            newClip = Random.Range(0, clips.Length);
        }
        while (usedClips.Contains(newClip));
        usedClips.Add(newClip);

        GetComponent<AudioSource>().clip = clips[newClip];
        GetComponent<AudioSource>().Play();

        GameObject.FindWithTag("Player").SendMessage("Trees");

        Invoke("PlayRandomSound", Random.Range(10f, 18f));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
