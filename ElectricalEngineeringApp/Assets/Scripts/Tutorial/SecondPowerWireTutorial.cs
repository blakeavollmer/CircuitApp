using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class SecondPowerWireTutorial : Tutorial, IInputClickHandler
    {


        public GameObject PositiveHole;
        public GameObject NegativeHole;
        public GameObject PositiveWireNine;
        public GameObject NegativeWireNine;
        public GameObject PositiveWireOne;
        public GameObject NegativeWireOne;
        public GameObject NineVolt;
        public GameObject OnePointFive;
        public GameObject NineConnect;
        public GameObject OneConnect;
        public GameObject LEDOff;
        public GameObject LEDOn;

        public GameObject nextTutorial;
        public GameObject previousTutorial;

        public AudioSource audioSource;

        public AudioClip Explain1;
        public AudioClip Explain2;
        public AudioClip negativeConnect;

        int count = 0;
        bool TaskCompleted = false;

        private void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
            PositiveHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        public override void CheckIfHappening()
        {
            if (TaskCompleted)
                return;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameObject currentObject = eventData.selectedObject;

           
            
                if (currentObject.name == "+1L" && count == 0)
                {


                    PositiveWireNine.SetActive(true);

                    count++;
                    PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                    NegativeHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                    NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    audioSource = GetComponent<AudioSource>();
                    audioSource.clip = negativeConnect;
                    audioSource.Play();
                }

                else if (currentObject.name == "-1R" && count == 1)
                {

                    NegativeWireNine.SetActive(true);


                    NineVolt.SetActive(false);
                    NineConnect.SetActive(true);
                    audioSource.clip = Explain2;
                    audioSource.Play();


                    count++;

                    LEDOff.SetActive(false);
                    LEDOn.SetActive(true);

                nextTutorial.GetComponent<VoltageChange>().enabled = true;
                previousTutorial.GetComponent<PowerSourceTutorial>().enabled = false;

                TaskCompleted = true;
                    this.enabled = false;


                    NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                    TutorialManager.Instance.CompletedTutorial();
                }
            }

        
    }
}