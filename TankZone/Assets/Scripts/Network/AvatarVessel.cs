using Photon.Pun;
using System.IO;
using UnityEngine;

public class AvatarVessel : MonoBehaviour
{
    public PhotonView view;

    private void Start()
    {
        RoundManager.roundManager.AddToQueue(this);
    }

    public void CreatePlayer()
    {
        if (view.IsMine)
        {
            Debug.Log("CreatePlayer");
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Tank"), transform.position, Quaternion.identity, 0);
        }
    }
}
