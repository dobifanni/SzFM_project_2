using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuButton : MonoBehaviour
{
    public void OnClick(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
