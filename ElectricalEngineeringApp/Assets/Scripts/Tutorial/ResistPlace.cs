using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistPlace : Tutorial, IInputClickHandler
{
    public GameObject HoleLeft;
    public GameObject HoleRight;
    public GameObject NineVolt;
    public GameObject OnePointFive;
    public GameObject ResistorNineConnect;
    public GameObject ResistorOneConnect;
    public GameObject ResistorNineStand;
    public GameObject ResistorOneStand;
    int count;
    bool TaskCompleted = false;

  

    // Use this for initialization
    void Start () {
        InputManager.Instance.AddGlobalListener(gameObject);


    }


	public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject currentObject = eventData.selectedObject;
        HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;

        if (currentObject.name == "+6L" && count == 0)
        {

            
            if (NineVolt.activeSelf)
            {
                ResistorNineStand.SetActive(true);

            }
            else
            {
                ResistorOneStand.SetActive(true);
                
            }
            count++;
            HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
            HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
            HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        else if (currentObject.name == "8A" && count == 1)
        {
            if (NineVolt.activeSelf)
            {
                ResistorNineStand.SetActive(false);
                ResistorNineConnect.SetActive(true);
            }
            else
            {
                ResistorOneStand.SetActive(false);
                ResistorOneConnect.SetActive(true);
            }
            HoleRight.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
            HoleRight.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
            HoleLeft.transform.GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
            HoleLeft.transform.GetComponent<MeshRenderer>().material.color = Color.clear;
            TaskCompleted = true;
            this.enabled = false;


            TutorialManager.Instance.CompletedTutorial();
        }
    }
}



