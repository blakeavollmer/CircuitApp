using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace BV.Hololens.EngineeringApp.Effects
{

    public class GazeMaterialToggle : MonoBehaviour, IFocusable
    {


        [Tooltip("Material displayed when gazed upon")]
        public Material[] activeMaterial;

        [Tooltip("Material displayed when not gazed upon")]
        public Material[] inactiveMaterial;

        private Renderer[] Renderers { get; set; }


        // Use this for initialization
        void Start()
        {
            

            Renderers = GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < inactiveMaterial.Length; i++)
            {
                SetMaterial(inactiveMaterial[i], i);
            }
                    
        }


        void IFocusable.OnFocusEnter()
        {
         for (int i = 0; i < activeMaterial.Length; i++)
             {
                SetMaterial(activeMaterial[i], i);
            }
        }

        void IFocusable.OnFocusExit()
        {

            for (int i = 0; i < inactiveMaterial.Length; i++)
                SetMaterial(inactiveMaterial[i], i);
        }

        private void SetMaterial(Material material, int i)
        {
            foreach (var renderer in Renderers)
            {
             
              renderer.material = material;
            }
        }
    }
}
