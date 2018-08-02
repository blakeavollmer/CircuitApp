using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class End : Introduction
{

    public GameObject menu;
    public GameObject tutorial;
    public AudioSource audioSource;
    public AudioClip endIntro;

    public Text changeText;
    bool TaskCompleted = false;


    // Use this for initialization
    void Start ()
    {
        menu.SetActive(true);
        tutorial.SetActive(true);
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = endIntro;
        this.GetComponent<AudioSource>().Play();
        if (this.enabled != false)
            changeText.text = "This concludes the introduction. Please select Menu or Tutorial.";

        TaskCompleted = true;
        this.enabled = false;
        // move to next in order
        IntroductionManager.Instance.CompletedAllIntroduction();

    }
	
	// Update is called once per frame
	void Update () {
		
	}



}


//                     OneConnect.SetActive(true);
