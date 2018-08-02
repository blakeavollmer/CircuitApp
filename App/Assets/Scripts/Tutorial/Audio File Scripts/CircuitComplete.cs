using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class CircuitComplete : Tutorial
    {

        public AudioSource audioSource;

        public AudioClip circtuiComplete;
        public AudioClip ohmsLaw;
        public AudioClip currentExp;

        bool TaskCompleted = false;

        IEnumerator Start()
        {

            audioSource = GetComponent<AudioSource>();

            audioSource.clip = circtuiComplete;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.clip = ohmsLaw;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.clip = currentExp;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);


            TaskCompleted = true;
            this.enabled = false;
            TutorialManager.Instance.CompletedTutorial();


        }


    }
}