using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class WelcomeAudio : Tutorial
    {

        public AudioSource audioSource;

        public AudioClip welcomeAudio;
        public AudioClip grabLED;
        bool TaskCompleted = false;

        IEnumerator Start()
        {

            audioSource = GetComponent<AudioSource>();

            audioSource.clip = welcomeAudio;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.clip = grabLED;
            audioSource.Play();

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