using Complete;
using Photon.Pun;
using UnityEngine;

public class TankLifecycler : MonoBehaviour
{
    public PhotonView view;

    private TankManager tankManager;

    private void Awake()
    {
        if (view.IsMine)
        {
            view.RPC(nameof(RegisterTank), RpcTarget.AllBuffered, PlayerProfile.profile.GetDisplayName());
        }
    }

    [PunRPC]
    private void RegisterTank(string playerName)
    {
        RegisterToGame(playerName);

        RegisterToCamera();
    }

    private void RegisterToGame(string playerName)
    {
        tankManager = new TankManager
        {
            m_Instance = gameObject,
            m_PlayerName = playerName,
        };

        tankManager.Setup();

        GameManager.gameManager.m_Tanks.Add(tankManager);
    }

    private void RegisterToCamera()
    {
        CameraControl.cameraControl.m_Targets.Add(transform);
    }

    private void OnDestroy()
    {
        RemoveFromGame();

        RemoveFromCamera();
    }

    private void RemoveFromGame()
    {
        GameManager.gameManager.m_Tanks.Remove(tankManager);
    }

    private void RemoveFromCamera()
    {
        CameraControl.cameraControl.m_Targets.Remove(transform);
    }
}
