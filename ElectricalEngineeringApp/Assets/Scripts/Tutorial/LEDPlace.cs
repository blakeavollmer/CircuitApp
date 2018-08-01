using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class LEDPlace : Tutorial, IInputClickHandler
    {
        public GameObject HoleLeft;
        public GameObject HoleRight;
        public GameObject LEDStand;
        public GameObject LEDSet;

        public AudioSource audioSource;

        public AudioClip positiveLead;
        public AudioClip negativeLead;
        public AudioClip goodJob;
        public AudioClip nextStep;

        public GameObject nextTutorial;
        public GameObject previousTutorial;

        int count;
        bool TaskCompleted = false;



        // Use this for initialization
        void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
            HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = positiveLead;
            audioSource.Play();
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







            if (currentObject.name == "8E" && count == 0)
            {
                LEDStand.SetActive(true);
                count++;
                //HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
                HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
                audioSource.clip = negativeLead;
                audioSource.Play();

            }

            else if (currentObject.name == "8F" && count == 1)
            {
                audioSource.clip = goodJob;
                audioSource.Play();
                new WaitForSeconds(audioSource.clip.length);
                LEDStand.SetActive(false);
                LEDSet.SetActive(true);
                count++;

                //HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
                HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                //HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
                HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.clear;

                audioSource.clip = nextStep;
                audioSource.Play();
                new WaitForSeconds(audioSource.clip.length);
                nextTutorial.GetComponent<ResistSelect>().enabled = true;
                previousTutorial.GetComponent<LEDSelect>().enabled = false;
                TaskCompleted = true;

                this.enabled = false;


                TutorialManager.Instance.CompletedTutorial();
            }
        }
    }
}
