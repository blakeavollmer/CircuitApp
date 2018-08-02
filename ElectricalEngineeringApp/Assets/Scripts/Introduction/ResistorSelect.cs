using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class ResistorSelect : Introduction, IInputClickHandler
{
    public AudioSource audioSource;
    public AudioClip resistorIntro;
    public Text changeText;

    bool TaskCompleted = false;

    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // play audio
        this.gameObject.AddComponent<AudioSource>();
        this.GetComponent<AudioSource>().clip = resistorIntro;
        this.GetComponent<AudioSource>().Play();

        // change text
        if (this.enabled != false)
            changeText.text = "The next component is a resistor. Resistors are used to reduce current flow " +
                "or to divide voltages. Each resistor can have a different value depending on the color of the bands.";

        //throw new System.NotImplementedException();

        TaskCompleted = true;
        this.enabled = false;
        // move to next in order
        IntroductionManager.Instance.CompletedIntroduction();
    }
}