using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class Rhymes : MonoBehaviour {

    private string poem = "he woke up early, after pain \n he fell asleep to sound of violence \n just to ignore another senseless form \n of crystal greed, deception brilliance _ \n among all good people not only him \n refused to choose unpleasant path \n the thing is that i have to carry sugar \n poor him should carry bag of salt _\n and still hes trying to ascend \n abyssal depths to sixth floor window \nfrom where you're trying to pretend \n that im far from center _\n so every time we dance through grapes \nof person's radiance, the gift \n he slightly smiles and so that means \nhe has just made a shift \n ";

    private string[] splittedPoem;
    private int currentBlock = 0;

    private Text text;

	void Start () {
        text = GetComponent<Text>();

        splittedPoem = poem.Split(new string[] { "_" }, StringSplitOptions.None);
        print(splittedPoem[currentBlock]);
        StartCoroutine("PrintText", splittedPoem[currentBlock]);

        text.DOFade(1f, 1.9f).SetDelay(0.4f);
	}

    IEnumerator PrintText(string fullText)
    {
        yield return new WaitForSeconds(0.6f);
        int currentChar = 0;
        while (text.text != fullText)
        {
            text.text = fullText.Substring(0, currentChar);
            currentChar = currentChar + 1;
            if (fullText[Mathf.Clamp(currentChar, 0, fullText.Length-1)] != ' ') yield return new WaitForSeconds(0.1f);
        }
        currentBlock++;
        if (currentBlock == splittedPoem.Length)
        {
            GameObject.FindWithTag("Lightning").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.2f);
            GameObject.FindWithTag("Player").SendMessage("Die");
            text.DOFade(0f, 1.4f).SetDelay(0.3f);
        }
        yield return new WaitForSeconds(7.19f);
        
        if (currentBlock == splittedPoem.Length)
        {
            //GameObject.FindWithTag("Player").SendMessage("Die");
        }
        else
        {
            StartCoroutine("PrintText", splittedPoem[currentBlock]);
        }
    }

	void Update () {

	}
}
