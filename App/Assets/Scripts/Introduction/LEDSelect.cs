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
    public GameObject previousTutorial;
    public GameObject nextTutorial;
    public GameObject LEDOff;
    public GameObject LEDOn;

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

        if (currentObject.name == "LED")
        {
            previousTutorial.GetComponent<AudioSource>().enabled = false;
            // CHANGE MATERIAL TO TRANSPARENT
            LEDOff.GetComponent<MeshRenderer>().enabled = false;
            LEDOn.SetActive(true);

            // play audio
            this.gameObject.AddComponent<AudioSource>();
            this.GetComponent<AudioSource>().clip = LEDIntro;
            this.GetComponent<AudioSource>().Play();
            StartCoroutine(Waiting());

            // change text
            if (this.enabled != false)
                changeText.text = "The next component is the light-emitting diode, or the LED. The LED is a " +
                    "semiconducting light source that has two leads- the longer, positive anode and the shorter, " +
                    "negative cathode. Light is emitted when the proper voltage is applied across the leads.";

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
        if (changeText.text == "The next component is the light-emitting diode, or the LED. The LED is a " +
                    "semiconducting light source that has two leads- the longer, positive anode and the shorter, " +
                    "negative cathode. Light is emitted when the proper voltage is applied across the leads.")
            changeText.text = "Select the Wire";
    }
}