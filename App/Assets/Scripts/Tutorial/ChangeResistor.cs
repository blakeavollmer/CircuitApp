using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Classes {
    public class ChangeResistor : Tutorial, IInputClickHandler {
        public GameObject bigResistor;
        public GameObject bigResistorNew;
        public GameObject smallResistor;
        public GameObject smallResistorNew;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameObject currentObject = eventData.selectedObject;
        }

        private void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
        }



    }
}

