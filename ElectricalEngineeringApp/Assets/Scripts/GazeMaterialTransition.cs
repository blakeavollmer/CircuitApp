
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Effects
{
    public class GazeMaterialTransition : GazeTransitionBase
    {
        [Tooltip("Material displayed when gazed upon")]
        public Material activeMaterial;

        [Tooltip("Material displayed when not gazed upon")]
        public Material inactiveMaterial;


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

            if (Renderer.materials.Length == 5)
                Renderer.materials[1].Lerp(inactiveMaterial, activeMaterial, transitionFactor);
            else if (Renderer.materials.Length == 2)
                Renderer.materials[1].Lerp(inactiveMaterial, activeMaterial, transitionFactor);
            else if (Renderer.materials.Length == 4)
                Renderer.materials[1].Lerp(inactiveMaterial, activeMaterial, transitionFactor);
            else
                Renderer.material.Lerp(inactiveMaterial, activeMaterial, transitionFactor);
        }
    }
}
