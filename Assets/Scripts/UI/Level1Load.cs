using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Load : MonoBehaviour
{
    public void Level1Scene()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
}
