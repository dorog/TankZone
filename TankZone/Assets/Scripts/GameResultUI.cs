using UnityEngine;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    public GameObject ui;
    public Text winner;

    public void ShowSingleWinner(string winnerName)
    {
        ui.SetActive(true);
        winner.text = winnerName + " won the game!";
    }
}
