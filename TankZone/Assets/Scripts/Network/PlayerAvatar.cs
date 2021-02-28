using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAvatar : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public PhotonView view;

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Finished loading: " + scene.buildIndex);
        if (view.IsMine && scene.buildIndex == GameSceneManager.gameScene)
        {
            Debug.Log("Entered...");
            //RoundManager.roundManager.AddToQueue(this);

            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "AvatarVessel"), transform.position, Quaternion.identity, 0);
        }
        else
        {
            Debug.Log("Not this time :(");
        }
    }
}
