using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

[System.Serializable]
public class Room
{
    public string name;
    public int scene;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<Room> listRoom;
    public GameObject roomUI;

    public InputField NickName;
    void Start()
    {
        //ServerConnect();
    }

    public void ServerConnect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        /*
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.JoinOrCreateRoom("skyroom", roomOptions, TypedLobby.Default);
        */

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.LocalPlayer.NickName = NickName.text;
        roomUI.SetActive(true);
    }

    public void CreateRoom(int roomIndex)
    {
        PhotonNetwork.LoadLevel(listRoom[roomIndex].scene);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.JoinOrCreateRoom(listRoom[roomIndex].name, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Room Join!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
