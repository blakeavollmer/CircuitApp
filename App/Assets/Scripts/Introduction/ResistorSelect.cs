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
    public GameObject nextTutorial;
    public GameObject previousTutorial;
    public Text changeText;

    bool TaskCompleted = false;

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);


    }

    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {

        GameObject currentObject = eventData.selectedObject;

        if (currentObject.name == "resistor1")
        {
            previousTutorial.GetComponent<AudioSource>().enabled = false;
            // play audio
            this.gameObject.AddComponent<AudioSource>();
            this.GetComponent<AudioSource>().clip = resistorIntro;
            this.GetComponent<AudioSource>().Play();
            StartCoroutine(Waiting());

            // change text
            if (this.enabled != false)
                changeText.text = "The next component is a resistor. Resistors are used to reduce current flow " +
                    "or to divide voltages. Each resistor can have a different value depending on the color of the bands.";

            nextTutorial.SetActive(true);
            TaskCompleted = true;
            this.enabled = false;
            // move to next in order
            IntroductionManager.Instance.CompletedIntroduction();
        }

        //throw new System.NotImplementedException();


    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length + 1);
        if (changeText.text == "The next component is a resistor. Resistors are used to reduce current flow " +
                    "or to divide voltages. Each resistor can have a different value depending on the color of the bands.")
        changeText.text = "Select the LED";
    }
}