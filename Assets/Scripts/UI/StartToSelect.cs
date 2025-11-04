using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToSelect : MonoBehaviour
{
    public void StartToSelectScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(2);
    }
}
