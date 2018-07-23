using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Effects
{

    public abstract class TransitionBehaviorBase : MonoBehaviour
    {
        [System.Serializable]
        public class TransitionOptions
        {
            [Tooltip("The time in seconds to transition from 0 to 1")]
            public float transitionInDuration = 1f;

            [Tooltip("The time in seconds to transition from 0 to 1")]
            public float transitionOutDuration = 1f;
        }


        public TransitionOptions transitionOptions;

        protected float transitionFactor;

        private static readonly YieldInstruction EndOfFrame = new WaitForEndOfFrame();


        public void TransitionIn()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine_TransitionTo(0, 1f, transitionOptions.transitionInDuration));
        }

        public void TransitionOut()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine_TransitionTo(1f, 0, transitionOptions.transitionOutDuration));
        }

        IEnumerator Coroutine_TransitionTo(float from, float to, float duration)
        {
            var rate = 1f / duration;
            var t = Mathf.InverseLerp(from, to, transitionFactor);
            while(t < 1f)
            {
                transitionFactor = Mathf.Lerp(from, to, t);

                t += rate * Time.deltaTime;
                yield return EndOfFrame;
            }

            transitionFactor = to;
        }
    }
}
