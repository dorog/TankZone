using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static int menuScene = 1;
    public static int gameScene = 2;

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
