using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class WirePlace : Tutorial, IInputClickHandler
    {
        public GameObject HoleLeft;
        public GameObject HoleRight;
        public GameObject WireStand;
        public GameObject WireSet;

        public GameObject nextTutorial;
        public GameObject previousTutorial;


        public AudioSource audioSource;

        public AudioClip selectPower;

        public Text changeText;

        int count;
        bool TaskCompleted = false;



        // Use this for initialization
        void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
            HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;


        }

        void Update()
        {
            if (count == 0)
            {
                HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            if (count == 1)
            {
                HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
        }


        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameObject currentObject = eventData.selectedObject;


            if (currentObject.name == "8J" && count == 0)
            {
                WireStand.SetActive(true);
                count++;
                //HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
                HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }

            else if (currentObject.name == "-6R" && count == 1)
            {
                WireStand.SetActive(false);
                WireSet.SetActive(true);
                
                count++;

                //HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
                HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                //HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
                HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.clear;

                audioSource = GetComponent<AudioSource>();

                audioSource.clip = selectPower;
                audioSource.Play();
                changeText.text = "Select the 1.5 Volt Battery.";

                nextTutorial.GetComponent<SecondPowerSource>().enabled = true;
                previousTutorial.GetComponent<WireSelect>().enabled = false;

                TaskCompleted = true;
                this.enabled = false;


                TutorialManager.Instance.CompletedTutorial();
            }
        }
    }
}