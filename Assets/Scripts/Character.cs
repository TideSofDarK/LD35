using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;

public class Character : MonoBehaviour {

    public float speed = 1.5f;
    public float curSpeed = 1.1f;

    public AudioSource breath;
    public GameObject karr;

    bool dead = false;

	// Use this for initialization
	void Start () {
        //Camera.main.transform.LookAt(transform.position + new Vector3(0,0,2f));
    }
	
	// Update is called once per frame
	void Update () {
        curSpeed = Mathf.Lerp(curSpeed, speed, Time.deltaTime * 2f);
        transform.Translate(transform.right * Time.deltaTime * curSpeed);
	}

    public void ShiftSpeed()
    {
        StartCoroutine("_ShiftSpeed");
    }

    IEnumerator _ShiftSpeed()
    {
        speed = 2.5f;

        yield return new WaitForSeconds(2.4f);

        speed = 1.5f;
    }

    public void Die()
    {
        if (!dead)
        {
            GetComponentInChildren<Animator>().SetBool("IsDead", true);
            GetComponent<AudioSource>().volume = 0f;
            breath.volume = 0f;
            speed = 0f;
            dead = true;

            GameObject.FindWithTag("Bell").GetComponent<AudioSource>().Play();

            Invoke("Karr", 2.6f);
            Invoke("Fade", 11f);
        }
    }

    public void Fade()
    {
        var blur = new BlurTransition()
        {
            nextScene = 2,
            duration = 2.0f,
            blurMax = 0.01f
        };
        TransitionKit.instance.transitionWithDelegate(blur);
    }

    public void Karr()
    {
        karr.SetActive(true);
    }

    public void Trees()
    {
        if (!dead)
        {
            ShiftSpeed();
        }
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 11);
        int i = 0;
        while (i < hitColliders.Length)
        {
            var animator = hitColliders[i].gameObject.GetComponent<Animator>();
            if (animator)
                animator.enabled = true;
            i++;
        }
    }
}
