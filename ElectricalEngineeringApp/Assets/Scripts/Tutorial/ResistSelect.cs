using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class ResistSelect : Tutorial, IInputClickHandler
    {
        bool TaskCompleted = false;

        public AudioSource audioSource;

        public AudioClip resistorPlace;

        public GameObject nextTutorial;
        public GameObject previousTutorial;

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


            //if (TutorialManager.FindCurrentTutorial() == 3)



            if (currentObject.name == "resistor1")
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = resistorPlace;
                audioSource.Play();
                new WaitForSeconds(audioSource.clip.length);
                eventData.Use();
                nextTutorial.GetComponent<ResistPlace>().enabled = true;
                previousTutorial.GetComponent<LEDPlace>().enabled = false;
                TaskCompleted = true;
                this.enabled = false;
                TutorialManager.Instance.CompletedTutorial();
            }
        }

    }
}