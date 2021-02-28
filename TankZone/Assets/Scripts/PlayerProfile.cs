using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProfile : MonoBehaviour
{
    private readonly string idKey = "displayName";
    private readonly string defaultNotExistValue = "Unknown";

    public static PlayerProfile profile;

    public GameObject nameSelector;

    private void Awake()
    {
        profile = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == GameSceneManager.menuScene)
        {
            if (IsDisplaynameNotSelected())
            {
                nameSelector.SetActive(true);
            }
        }
    }

    public bool IsDisplaynameNotSelected()
    {
        string id = PlayerPrefs.GetString(idKey, defaultNotExistValue);

        return id == defaultNotExistValue;
    }

    public void SetDisplayName(string name)
    {
        PlayerPrefs.SetString(idKey, name);
    }

    public string GetDisplayName()
    {
        return PlayerPrefs.GetString(idKey, defaultNotExistValue);
    }
}
