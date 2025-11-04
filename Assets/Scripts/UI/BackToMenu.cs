using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BackToMenuScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(1);
    }
}
