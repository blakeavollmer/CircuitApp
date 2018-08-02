using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class breadboardConnection : Introduction, IInputClickHandler
{
    public AudioSource audioSource;
    public AudioClip breadboardConnect;

    public Text changeText;

    bool TaskCompleted = false;

    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // play audio
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = breadboardConnect;
        this.GetComponent<AudioSource>().Play();

        // change text
        if (this.enabled != false)
            changeText.text = "On either side of the breadboard are voltage rails. The positive is denoted by red and " +
                "the negative is denoted by blue. While a single column is electrically connected together, each rail is " +
                "independent of each other. Each row of the breadboard is also electrically connected " +
                "and separated by the bridge in the center.";

        //throw new System.NotImplementedException();

        TaskCompleted = true;
        this.enabled = false;
        // move to next in order
        IntroductionManager.Instance.CompletedIntroduction();
    }

}