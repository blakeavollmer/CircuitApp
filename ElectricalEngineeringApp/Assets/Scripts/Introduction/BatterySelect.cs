using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class BatterySelect : Introduction, IInputClickHandler
{
    public AudioSource audioSource;
    public AudioClip batteryIntro;
    public Text changeText;

    bool TaskCompleted = false;


    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // play audio
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = batteryIntro;
        this.GetComponent<AudioSource>().Play();

        // change text
        if (this.enabled != false)
            changeText.text = "Look at the components in front of you. " +
                "The leftmost component is the 9 volt battery. This is a DC power source. " +
                "To the right of this is a 1.5 volt battery. It is also a DC power source " +
                "but with less voltage than the 9 volt.";

        //throw new System.NotImplementedException();

        TaskCompleted = true;
        this.enabled = false;
        IntroductionManager.Instance.CompletedIntroduction();
    }
}
