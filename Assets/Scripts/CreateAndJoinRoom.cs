using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{

    

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("A");
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("A");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("WaitingRoom");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

}
