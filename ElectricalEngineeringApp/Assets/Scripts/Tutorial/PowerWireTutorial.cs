using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BV.Hololens.EngineeringApp.Classes
{
    [RequireComponent(typeof(AudioSource))]
    public class PowerWireTutorial : Tutorial, IInputClickHandler
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

        public GameObject AnimationObject;

        public AudioSource audioSource;

        public AudioClip Explain1;
        public AudioClip Explain2;
        public AudioClip negativeConnect;

        public Text changeText;

        Animator anim;


        int count = 0;
        bool TaskCompleted = false;

        private void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
            PositiveHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
            anim = GetComponent<Animator>();
            anim.enabled = false;
            AnimationObject.SetActive(false);


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


            if (currentObject.name == "+1L" && count == 0 || count == 2)
            {
                previousTutorial.GetComponent<AudioSource>().enabled = false;
                //NineVolt.GetComponentInParent<MeshRenderer>().enabled = true;
                if (NineVolt.activeSelf)
                {
                    PositiveWireNine.SetActive(true);
                    //NegativeWireNine.SetActive(false);
                }
                else
                {
                    PositiveWireOne.SetActive(true);
                    //NegativeWireOne.SetActive(true);
                }
                count++;
                PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                NegativeHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
                audioSource = GetComponent<AudioSource>();

                audioSource.clip = negativeConnect;
                audioSource.Play();
                changeText.text = "Now we are going to connect the negative black wire. Select the highlighted hole to place the wire.";
            }

            else if (currentObject.name == "-1R" && count == 1 || count == 3)
            {
                audioSource.Stop();
                if (NineVolt.activeSelf)
                {
                    NegativeWireNine.SetActive(true);
                }
                else
                {
                    NegativeWireOne.SetActive(true);
                }
                if (NineVolt.activeSelf)
                {
                    NineVolt.SetActive(false);
                    NineConnect.SetActive(true);
                    audioSource.clip = Explain2;
                    audioSource.Play();
                    waitForSeconds(audioSource);
                }
                else
                {
                    OnePointFive.SetActive(false);
                    OneConnect.SetActive(true);
                    audioSource.clip = Explain1;
                    audioSource.Play();
                    changeText.text = "You have completed your first circuit. The electrons flow from the negative source to the positive source. This is what we call an electric current.";

                }
                count++;

                LEDOff.SetActive(false);
                LEDOn.SetActive(true);

                AnimationObject.SetActive(true);
                anim.enabled = true;
                anim.Play("3vAnimation");

                StartCoroutine(Waiting9());

                StartCoroutine(Waiting12());
                StartCoroutine(Waiting10());





                nextTutorial.GetComponent<PowerSourceTutorial>().enabled = true;
                previousTutorial.GetComponent<SecondPowerSource>().enabled = false;

                TaskCompleted = true;
                this.enabled = false;


                NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
                TutorialManager.Instance.CompletedTutorial();
            }
        }
        IEnumerator waitForSeconds(AudioSource audio)
        {
            yield return new WaitForSeconds(audio.clip.length);
        }

        IEnumerator Waiting9()
        {
            yield return new WaitForSeconds(9);

                changeText.text = "We can also calculate Ohm’s Law. Ohm’s Law states that the electrical current flowing through a fixed linear resistance is directly proportional to the voltage applied across it and is also inversely proportional to the resistance.";
        }

        IEnumerator Waiting10()
        {
            yield return new WaitForSeconds(35);

                changeText.text = "Let's try a different voltage. Select the 9 Volt Battery.";

        }

        IEnumerator Waiting12()
        {
            yield return new WaitForSeconds(23);

                changeText.text = "The current is equal to voltage over resistance. Our voltage is 3, and our resistance is 270 ohm. This means our current is .01 amps.";

        }
    }
}