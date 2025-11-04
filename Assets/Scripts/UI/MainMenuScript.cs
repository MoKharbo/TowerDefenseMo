using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void MainMenuScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(1);
    }
}
