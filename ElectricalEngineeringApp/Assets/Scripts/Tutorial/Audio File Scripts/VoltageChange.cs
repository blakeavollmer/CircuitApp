using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class VoltageChange : Tutorial
    {

        public AudioSource audioSource;

        public AudioClip voltageChanged;


        public GameObject oldResistor;
        public GameObject newResistor;
        public GameObject placedOldResistor;
        public GameObject placedNewResistor;
        public GameObject homeScreen;

 
        public GameObject previousTutorial;

        bool TaskCompleted = false;

        void Start()
        {
            previousTutorial.GetComponent<AudioSource>().enabled = false;
            audioSource = GetComponent<AudioSource>();

            audioSource.clip = voltageChanged;
            audioSource.Play();



            oldResistor.SetActive(false);
            newResistor.SetActive(true);

            placedOldResistor.SetActive(false);
            placedNewResistor.SetActive(true);

            waitForSeconds(audioSource);

            homeScreen.SetActive(true);


            previousTutorial.GetComponent<SecondPowerWireTutorial>().enabled = false;


            TaskCompleted = true;
            this.enabled = false;
            TutorialManager.Instance.CompletedTutorial();


        }
        IEnumerator waitForSeconds(AudioSource audio)
        {
            yield return new WaitForSeconds(audio.clip.length);
        }

    }


    
}