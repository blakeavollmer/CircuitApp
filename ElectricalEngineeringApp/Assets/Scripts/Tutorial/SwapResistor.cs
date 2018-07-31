using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class SwapResistor : Tutorial, IInputClickHandler
    {
        bool TaskCompleted = false;

        public GameObject oldResistor;
        public GameObject newResistor;
        public GameObject previousTutorial;

        public AudioSource audioSource;

        public AudioClip resistorInfo;

        public void Start()
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

            if (currentObject.name == "resistor2")
            {
                eventData.Use();
                oldResistor.SetActive(false);
                newResistor.SetActive(true);

                audioSource = GetComponent<AudioSource>();

                audioSource.clip = resistorInfo;
                audioSource.Play();

                previousTutorial.GetComponent<VoltageChange>().enabled = false;
                TaskCompleted = true;
                this.enabled = false;
                TutorialManager.Instance.CompletedTutorial();
            }
    }
}
}