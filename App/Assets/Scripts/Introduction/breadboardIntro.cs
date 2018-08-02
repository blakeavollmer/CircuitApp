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
    public AudioClip breadboard2;
    public AudioClip endIntro;
    public GameObject previousTutorial;

    public GameObject Menu;
    public GameObject Tutorial;

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

        if (currentObject.name == "breadboard" || currentObject.name == "Breadboard Holes")
        {
            previousTutorial.GetComponent<AudioSource>().enabled = false;
            // play audio
            this.gameObject.AddComponent<AudioSource>();
            this.GetComponent<AudioSource>().clip = breadboard;
            this.GetComponent<AudioSource>().Play();

            // change text
            if (this.enabled != false)
                changeText.text = "The final component is the breadboard. This is used to connect all of the components when " +
                    "creating a circuit. A breadboard is connected in a specific way.";

           StartCoroutine(Waiting());


        }

       /* nextTutorial.SetActive(true);
        TaskCompleted = true;
        this.enabled = false;
        // move to next in order
        IntroductionManager.Instance.CompletedIntroduction();*/
    }


    // This is a much more verbose version of the Waiting function used in previous scripts but with the same idea.
    // Each time a new WaitForSeconds is called, it waits that amount of time before making any changes.
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);
        changeText.text = "On either side of the breadboard are voltage rails. The positive is denoted by red and " +
                "the negative is denoted by blue.";
        this.GetComponent<AudioSource>().clip = breadboard2;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(8);
        changeText.text = "While a single column is electrically connected together, each rail is " +
                "independent of each other.";
        yield return new WaitForSeconds(6);
        changeText.text = "Each row of the breadboard is also electrically connected " +
                "and separated by the bridge in the center.";
        yield return new WaitForSeconds(6);
        this.GetComponent<AudioSource>().clip = endIntro;
        this.GetComponent<AudioSource>().Play();
        changeText.text = "This concludes the introduction. Please select Menu or Tutorial.";
        Menu.SetActive(true);
        Tutorial.SetActive(true);

    }


}
