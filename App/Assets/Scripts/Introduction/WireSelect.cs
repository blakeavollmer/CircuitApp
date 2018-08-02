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
    public GameObject nextTutorial;
    public GameObject previousTutorial;
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

        if (currentObject.name == "Wire")
        {
            LEDOff.GetComponent<MeshRenderer>().enabled = true;
            LEDOn.SetActive(false);
            previousTutorial.GetComponent<AudioSource>().enabled = false;
            // play audio
            this.gameObject.AddComponent<AudioSource>();
            this.GetComponent<AudioSource>().clip = wireIntro;
            this.GetComponent<AudioSource>().Play();
            StartCoroutine(Waiting());

            // change text
            if (this.enabled != false)
                changeText.text = "Next, there is an insulated copper wire. Wires are used to transport an electrical charge. " +
                    "Inside these wires are copper, which has the highest electrical conductivity rating" +
                    " of all non-precious metals.";

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
        if (changeText.text == "Next, there is an insulated copper wire. Wires are used to transport an electrical charge. " +
                    "Inside these wires are copper, which has the highest electrical conductivity rating" +
                    " of all non-precious metals.")
            changeText.text = "Select the Breadboard";
    }
}
