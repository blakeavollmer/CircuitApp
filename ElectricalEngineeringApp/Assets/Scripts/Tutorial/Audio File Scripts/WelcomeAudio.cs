using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class WelcomeAudio : Tutorial
    {

        public AudioSource audioSource;

        public AudioClip welcomeAudio;
        public AudioClip grabLED;
        public Text changeText;
        

        bool TaskCompleted = false;

        IEnumerator Start()
        {

            audioSource = GetComponent<AudioSource>();

            
            audioSource.clip = welcomeAudio;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.clip = grabLED;
            audioSource.Play();
            if (this.enabled != false)
                changeText.text = "To start, select the LED.";






            waitForSeconds(audioSource);

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