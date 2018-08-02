using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Effects
{
    public abstract class GazeTransitionBase : TransitionBehaviorBase, IFocusable
    {
        public void OnFocusEnter()
        {
            TransitionIn();
        }

        public void OnFocusExit()
        {
            TransitionOut();
        }



     
    }
}