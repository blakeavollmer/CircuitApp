using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class LEDSelect : Introduction, IInputClickHandler
{
    public AudioSource audioSource;
    public AudioClip LEDIntro;
    public Text changeText;

    bool TaskCompleted = false;

    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {

        // CHANGE MATERIAL TO TRANSPARENT

        // play audio
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = LEDIntro;
        this.GetComponent<AudioSource>().Play();

        // change text
        if (this.enabled != false)
            changeText.text = "The next component is the light-emitting diode, or the LED. The LED is a " +
                "semiconducting light source that has two leads- the longer, positive anode and the shorter, " +
                "negative cathode. Light is emitted when the proper voltage is applied across the leads.";

        //throw new System.NotImplementedException();

        TaskCompleted = true;
        this.enabled = false;
        // move to next in order
        IntroductionManager.Instance.CompletedIntroduction();
    }
}