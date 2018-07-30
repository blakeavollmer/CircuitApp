﻿using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistSelect : Tutorial, IInputClickHandler
{
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

        if (currentObject.name == "resistor1")
        {
            eventData.Use();
            TaskCompleted = true;
            this.enabled = false;
            TutorialManager.Instance.CompletedTutorial();
        }
    }

}