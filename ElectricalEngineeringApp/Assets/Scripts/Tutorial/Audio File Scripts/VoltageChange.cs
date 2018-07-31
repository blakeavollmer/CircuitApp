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
        public AudioClip selectResistor;

        public GameObject oldResistor;
        public GameObject newResistor;

        public GameObject nextTutorial;
        public GameObject previousTutorial;

        bool TaskCompleted = false;

        IEnumerator Start()
        {

            audioSource = GetComponent<AudioSource>();

            audioSource.clip = voltageChanged;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.clip = selectResistor;
            audioSource.Play();

            oldResistor.SetActive(false);
            newResistor.SetActive(true);

            nextTutorial.GetComponent<SwapResistor>().enabled = true;
            previousTutorial.GetComponent<SecondPowerWireTutorial>().enabled = false;


            TaskCompleted = true;
            this.enabled = false;
            TutorialManager.Instance.CompletedTutorial();


        }


    }
}