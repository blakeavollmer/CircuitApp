using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    public class LEDSelect : Tutorial, IInputClickHandler
    {
        bool TaskCompleted = false;
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

            if (currentObject.name == "LED")
            {
                eventData.Use();
                nextTutorial.GetComponent<LEDPlace>().enabled = true;
                previousTutorial.GetComponent<WelcomeAudio>().enabled = false;
                TaskCompleted = true;
                this.enabled = false;
                TutorialManager.Instance.CompletedTutorial();
            }
        }

    }
}
