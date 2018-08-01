using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class TutorialComplete : Tutorial
    {

        public AudioSource audioSource;

        public AudioClip completedAudio;
        bool TaskCompleted = false;

        IEnumerator Start()
        {

            audioSource = GetComponent<AudioSource>();

            audioSource.clip = completedAudio;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);


            TaskCompleted = true;
            this.enabled = false;
            TutorialManager.Instance.CompletedTutorial();
        }


    }
}