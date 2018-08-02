using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class WireSelect : Introduction, IInputClickHandler
{
    public AudioSource audioSource;
    public AudioClip wireIntro;
    public Text changeText;

    bool TaskCompleted = false;

    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // play audio
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = wireIntro;
        this.GetComponent<AudioSource>().Play();

        // change text
        if (this.enabled != false)
            changeText.text = "Next, there is an insulated copper wire. Wires are used to transport an electrical charge. " +
                "Inside these wires are copper, which has the highest electrical conductivity rating" +
                " of all non-precious metals.";

        //throw new System.NotImplementedException();

        TaskCompleted = true;
        this.enabled = false;
        // move to next in order
        IntroductionManager.Instance.CompletedIntroduction();
    }
}
