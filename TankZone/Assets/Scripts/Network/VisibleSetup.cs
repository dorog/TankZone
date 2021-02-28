using Photon.Pun;
using UnityEngine;

public class VisibleSetup : MonoBehaviour
{
    public Material color;

    public MeshRenderer[] parts;
    public PhotonView view;

    void Start()
    {
        if (view.IsMine)
        {
            foreach(var mat in parts)
            {
                var materials = mat.materials;
                materials[0] = color;
                mat.materials = materials;
            }
        }
    }
}
