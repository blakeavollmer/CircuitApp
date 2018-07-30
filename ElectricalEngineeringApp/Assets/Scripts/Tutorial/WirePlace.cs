using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePlace : Tutorial, IInputClickHandler
{
    public GameObject HoleLeft;
    public GameObject HoleRight;
    public GameObject WireStand;
    public GameObject WireSet;
    public GameObject LEDOff;
    public GameObject LEDOn;

    int count;
    bool TaskCompleted = false;



    // Use this for initialization
    void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);


    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject currentObject = eventData.selectedObject;

        HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        if (currentObject.name == "8J" && count == 0)
        {
            WireStand.SetActive(true);
            count++;
            HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
            HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
            HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        else if (currentObject.name == "-6R" && count == 1)
        {
            WireStand.SetActive(false);
            WireSet.SetActive(true);
            LEDOff.SetActive(false);
            LEDOn.SetActive(true);
            count++;

            HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
            HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
            HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
            HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.clear;

            TaskCompleted = true;
            this.enabled = false;


            TutorialManager.Instance.CompletedTutorial();
        }
    }
}