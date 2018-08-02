using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadTutorialScene : MonoBehaviour
{

    public void ChangeScene(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
    }
}