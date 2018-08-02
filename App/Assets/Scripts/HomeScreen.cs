using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeScreen : MonoBehaviour, IInputClickHandler {

    private void Start()
    {
        InputManager.Instance.AddGlobalListener(gameObject);

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {

        GameObject currentObject = eventData.selectedObject;

        if (currentObject.name == "CoffeeCup")
        {
            SceneManager.LoadScene(0);
        }
    }

}
