using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class breadboardIntro : Introduction, IInputClickHandler
{
    public AudioSource audioSource;
    public AudioClip breadboard;
    public Text changeText;

    bool TaskCompleted = false;

    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // play audio
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = breadboard;
        this.GetComponent<AudioSource>().Play();

        // change text
        if (this.enabled != false)
            changeText.text = "The first component is the breadboard. This is used to connect all of the components when " +
                "creating a circuit. A breadboard is connected in a specific way.";
                
        TaskCompleted = true;
        this.enabled = false;
        // move to next in order
        IntroductionManager.Instance.CompletedIntroduction();
    }

}
