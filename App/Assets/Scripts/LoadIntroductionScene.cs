using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadIntroductionScene : MonoBehaviour
{

    public void ChangeScene(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
    }
}
