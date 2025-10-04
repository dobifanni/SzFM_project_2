using UnityEngine;
using UnityEngine.SceneManagement;
public class StartgameButtonUI : MonoBehaviour
{
    
    public void Palyatoltes(string sceneNev)
    {
        SceneManager.LoadScene(sceneNev);
    }
}
