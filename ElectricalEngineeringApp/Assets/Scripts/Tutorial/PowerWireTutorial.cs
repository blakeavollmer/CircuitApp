using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    int count = 0;
    bool TaskCompleted = false;

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
        PositiveHole.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        PositiveHole.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;


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
        }

        else if (currentObject.name == "-1R" && count == 1)
        {
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
            }
            else
            {
                OnePointFive.SetActive(false);
                OneConnect.SetActive(true);
            }
            TaskCompleted = true;
            this.enabled = false;

            
            NegativeHole.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
            TutorialManager.Instance.CompletedTutorial();
        }
    }

}
