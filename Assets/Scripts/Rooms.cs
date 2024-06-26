using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Rooms : MonoBehaviour
{
   public void QuickGame()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
}
