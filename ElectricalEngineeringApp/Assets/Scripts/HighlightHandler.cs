using UnityEngine;
using HoloToolkit.Unity.InputModule;
[RequireComponent(typeof(Renderer))]
public class HighlightHandler : MonoBehaviour, IFocusable
{
    [SerializeField]
    private Color highlightColor;
    private Color initialColor;
    private Renderer rendererInstance;
    private Material materialInstance;
 

    private void Awake()
    {
        rendererInstance = GetComponent<Renderer>();
        materialInstance = rendererInstance.material;
        initialColor = materialInstance.color;
    }
    private void OnDestroy()
    {
        Destroy(materialInstance);
    }

    void IFocusable.OnFocusEnter()
    {
        materialInstance.color = highlightColor;
    }
    void IFocusable.OnFocusExit()
    {
        materialInstance.color = initialColor;
    }
}