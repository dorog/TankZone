using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour
{
    public static GameSetup gameSetup;

    public Transform[] spawnPoints;

    private readonly List<Transform> availableSpawnPoints = new List<Transform>();

    public Action leaveRoom;

    private void Awake()
    {
        gameSetup = this;
    }

    public void SetupForNewRound()
    {
        availableSpawnPoints.Clear();

        availableSpawnPoints.AddRange(spawnPoints);
    }

    public Transform GetRandomSpawnPoint()
    {
        int spawnPoint = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
        Transform selectedTransform = availableSpawnPoints[spawnPoint];

        availableSpawnPoints.RemoveAt(spawnPoint);

        return selectedTransform;
    }
}
