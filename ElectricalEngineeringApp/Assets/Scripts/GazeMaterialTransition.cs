
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Effects
{
    public class GazeMaterialTransition : GazeTransitionBase
    {
        [Tooltip("Material displayed when gazed upon")]
        public Material activeMaterial;

        [Tooltip("Material displayed when not gazed upon")]
        public Material[] inactiveMaterial;


        private Renderer Renderer { get; set; }
        // Use this for initialization
        void Start()
        {
            Renderer = GetComponentInChildren<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Renderer == null)
                return;
            for (int i = 0; i < inactiveMaterial.Length; i++)
                Renderer.material.Lerp(inactiveMaterial[i], activeMaterial, transitionFactor);
        }
    }
}
