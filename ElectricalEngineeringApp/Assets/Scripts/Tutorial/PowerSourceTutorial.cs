using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class PowerSourceTutorial : Tutorial, IInputClickHandler
    {
        public GameObject AnimationObject;

        public AudioSource audioSource;

        public AudioClip positiveWire;

        public GameObject OnePointFiveVolt; 
        public GameObject NineVolt;

        public GameObject LEDOff;
        public GameObject LEDOn;

        public GameObject oldPositive;
        public GameObject oldNegative;

        public GameObject nextTutorial;
        public GameObject previousTutorial;



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

            if (currentObject.name == "9v")
            {
                AnimationObject.SetActive(false);
                previousTutorial.GetComponent<Animator>().enabled = false;
                previousTutorial.GetComponent<AudioSource>().enabled = false;
                eventData.Use();
                audioSource = GetComponent<AudioSource>();

                audioSource.clip = positiveWire;
                audioSource.Play();
                NineVolt.SetActive(true);
                OnePointFiveVolt.SetActive(false);
                LEDOn.SetActive(false);
                LEDOff.SetActive(true);
                oldNegative.SetActive(false);
                oldPositive.SetActive(false);


                nextTutorial.GetComponent<SecondPowerWireTutorial>().enabled = true;
                previousTutorial.GetComponent<PowerWireTutorial>().enabled = false;

                TaskCompleted = true;
                this.enabled = false;
                TutorialManager.Instance.CompletedTutorial();
            }

        }

    }
}
