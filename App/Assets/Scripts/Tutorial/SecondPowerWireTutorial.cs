using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        public GameObject AnimationObject;

        public GameObject oldResistor;
        public GameObject newResistor;
        public GameObject placedOldResistor;
        public GameObject placedNewResistor;
        public GameObject homeScreen;

        public GameObject nextTutorial;
        public GameObject previousTutorial;

        public AudioSource audioSource;

        public AudioClip Explain1;
        public AudioClip voltageChanged;

        public Text changeText;

        Animator anim;


        int count = 0;
        bool TaskCompleted = false;

        private void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
            PositiveHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        void Update()
        {
            if (count == 0)
            {
                PositiveHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            if (count == 1)
            {
                NegativeHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
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
                    previousTutorial.GetComponent<AudioSource>().enabled = false;

                    PositiveWireNine.SetActive(true);

                    count++;
                    PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                    NegativeHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                    NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    audioSource = GetComponent<AudioSource>();

                }

                else if (currentObject.name == "-1R" && count == 1)
                {
                audioSource.Stop();
                NegativeWireNine.SetActive(true);


                NineVolt.SetActive(false);
                NineConnect.SetActive(true);



                count++;

                LEDOff.SetActive(false);
                LEDOn.SetActive(true);

                audioSource.clip = voltageChanged;
                audioSource.Play();
                changeText.text = "When we increase the voltage, we should also increase the resistance. See that the resistor has changed -this is a 1,000 ohm resistor.";
                StartCoroutine(Waiting());




                oldResistor.SetActive(false);
                newResistor.SetActive(true);

                placedOldResistor.SetActive(false);
                placedNewResistor.SetActive(true);

                

                

                AnimationObject.SetActive(true);
                anim.enabled = true;
                anim.Play("9vAnimation");

               // nextTutorial.GetComponent<VoltageChange>().enabled = true;
                previousTutorial.GetComponent<PowerSourceTutorial>().enabled = false;

                //TaskCompleted = true;
                //this.enabled = false;


                NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                //TutorialManager.Instance.CompletedTutorial();
                }
            }
        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(10);
            changeText.text = "This completes the tutorial. Thank you for using the Electrical Circuits App!";
            homeScreen.SetActive(true);
        }
        
    }
}