using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class WireSelect : Tutorial, IInputClickHandler
    {
        bool TaskCompleted = false;
        public AudioSource audioSource;

        public AudioClip selectWire;

        public GameObject nextTutorial;
        public GameObject previousTutorial;

        public Text changeText;

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

            if (currentObject.name == "Wire")
            {
                previousTutorial.GetComponent<AudioSource>().enabled = false;
                eventData.Use();
                audioSource = GetComponent<AudioSource>();

                audioSource.clip = selectWire;
                audioSource.Play();
                changeText.text = "Select the highlighted hole to place the wire.";
                nextTutorial.GetComponent<WirePlace>().enabled = true;
                previousTutorial.GetComponent<ResistPlace>().enabled = false;
                TaskCompleted = true;
                this.enabled = false;
                TutorialManager.Instance.CompletedTutorial();
            }
        }

    }
}