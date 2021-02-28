using UnityEngine;
using UnityEngine.UI;

public class DisplayNameSelector : MonoBehaviour
{
    public InputField displayNameInput;
    public Button setDisplayNameButton;

    public PlayerProfile profile;

    public void DisplayNameChanged()
    {
        string value = displayNameInput.text;
        if (string.IsNullOrEmpty(value))
        {
            setDisplayNameButton.interactable = false;
        }
        else
        {
            setDisplayNameButton.interactable = true;
        }
    }

    public void SetDisplayName()
    {
        profile.SetDisplayName(displayNameInput.text);

        gameObject.SetActive(false);
    }
}
