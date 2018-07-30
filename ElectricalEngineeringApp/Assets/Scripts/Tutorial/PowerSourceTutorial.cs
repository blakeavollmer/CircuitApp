using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSourceTutorial : Tutorial, IInputClickHandler {


    public GameObject OnePointFiveVolt; // = GameObject.Find("Housing");
    public GameObject NineVolt; 
    bool TaskCompleted = false;

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);

    }
    
    public override void CheckIfHappening()
    {
        if (TaskCompleted)
            return;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject currentObject = eventData.selectedObject;

        if (currentObject.name == "9v")
        {
            eventData.Use();
            NineVolt.SetActive(true);
            OnePointFiveVolt.SetActive(false);
            TaskCompleted = true;
            this.enabled = false;
            TutorialManager.Instance.CompletedTutorial();
        }

        else if (currentObject.name == "Cylinder_004")
        {
            eventData.Use();
            OnePointFiveVolt.SetActive(true);
            NineVolt.SetActive(false);
            TaskCompleted = true;
            this.enabled = false;
            TutorialManager.Instance.CompletedTutorial();
            
        }
    }

}
