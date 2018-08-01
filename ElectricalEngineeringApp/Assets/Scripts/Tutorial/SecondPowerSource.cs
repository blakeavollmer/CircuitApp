using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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