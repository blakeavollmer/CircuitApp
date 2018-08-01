using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class SecondPowerSource : Tutorial, IInputClickHandler
    {


        public GameObject OnePointFiveVolt;
        public GameObject NineVolt;

        public AudioSource audioSource;

        public AudioClip positiveConnect;

        public GameObject nextTutorial;
        public GameObject previousTutorial;

        public Text changeText;


        bool TaskCompleted = false;

        private void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);


        }

        public override void CheckIfHappening()
        {
            if (TaskCompleted)
                return;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameObject currentObject = eventData.selectedObject;

            if (currentObject.name == "Cylinder_004")
            {
                previousTutorial.GetComponent<AudioSource>().enabled = false;
                eventData.Use();
                OnePointFiveVolt.SetActive(true);
                NineVolt.SetActive(false);
                audioSource = GetComponent<AudioSource>();

                audioSource.clip = positiveConnect;
                audioSource.Play();
                changeText.text = "Look at the leftmost column of the breadboard. This is called a positive rail. We are going to connect the positive red wire first. Select the hightlighted hole to place the wire.";

                waitForSeconds(audioSource);

                nextTutorial.GetComponent<PowerWireTutorial>().enabled = true;
                previousTutorial.GetComponent<WirePlace>().enabled = false;

                TaskCompleted = true;
                this.enabled = false;
                TutorialManager.Instance.CompletedTutorial();


            }
        }
        IEnumerator waitForSeconds(AudioSource audio)
        {
            yield return new WaitForSeconds(audio.clip.length);
        }

    }
}