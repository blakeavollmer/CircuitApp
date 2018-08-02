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
    public GameObject nextTutorial;
    public Text changeText;

    bool TaskCompleted = false;

    // I added a start function for all of the scripts associated with the introduction manager that instantiates 
    // an input manager that is used for handling what is being clicked. This is so that the scripts don't
    // need to be directly associated with an object but rather clicks check what the object is.
    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);

    }

    // when clicked
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // This creates an object called current object that checks the eventData for the object that was clicked
        // This was added to all of the scripts
        GameObject currentObject = eventData.selectedObject;

        // play audio
        this.gameObject.AddComponent<AudioSource>();

        // Added if statement to all of the scripts that makes sure the object is what is expected. Simply 
        // make sure the name component of currentObject is what the item is called in the Hierarchy
        // Only plays audio if they selected the correct item.
        if (currentObject.name == "9v")
        {

            this.GetComponent<AudioSource>().clip = batteryIntro;
            this.GetComponent<AudioSource>().Play();
            
            // In order for the waiting function to work currectly, we must call it using the StartCoroutine function
            // and passing our wait function as a parameter.
            StartCoroutine (Waiting());

            // change text

            changeText.text = "Look at the components in front of you. " +
                "The leftmost component is the 9 volt battery. This is a DC power source. " +
                "To the right of this is a 1.5 volt battery. It is also a DC power source " +
                "but with less voltage than the 9 volt.";

            // All scripts were given a new nextTutorial gameobject that holds the objects in the introduction manager
            // The following part of the tutorial does not play unless the previous one is completed
            nextTutorial.SetActive(true);
            TaskCompleted = true;
            this.enabled = false;
            IntroductionManager.Instance.CompletedIntroduction();
        }
        //throw new System.NotImplementedException();


    }

    // I've added these scripts to change the text box to tell the user what object to select next once the current
    // explanation finishes. The type must be IEnumerator. All functions have something similar added.
    IEnumerator Waiting()
    {
        // This is the actual wait time. It waits for the duration of the audio clip before changing the text
        // I am calling this function right after calling play in the function above.
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);
        if (changeText.text == "Look at the components in front of you. " +
                "The leftmost component is the 9 volt battery. This is a DC power source. " +
                "To the right of this is a 1.5 volt battery. It is also a DC power source " +
                "but with less voltage than the 9 volt.")
            changeText.text = "Select the Resistor";
    }
}
