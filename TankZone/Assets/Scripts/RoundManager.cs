using Complete;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager roundManager;
    public GameManager gameManager;

    private readonly List<AvatarVessel> queue = new List<AvatarVessel>();

    private bool isFirstRound = true;

    public int queueLimit = 1;

    private void Awake()
    {
        roundManager = this;
    }

    public void AddToQueue(AvatarVessel vessel)
    {
        if (isFirstRound)
        {
            Debug.Log("First round. :P");
            queue.Add(vessel);

            Debug.Log("Players in queue: " + queue.Count);
            Debug.Log("Limit: " + queueLimit);

            if (queue.Count > queueLimit)
            {
                StartFirstRound();
            }
        }
        else
        {
            vessel.CreatePlayer();
        }
    }

    private void StartFirstRound()
    {
        Debug.Log("F: " + queue.Count);
        foreach(var vessel in queue)
        {
            Debug.Log("Player...");
            vessel.CreatePlayer();
        }

        isFirstRound = false;

        Debug.Log("Start first round2");

        gameManager.StartGame(queue.Count);

        queue.Clear();
    }
}
