using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// this is based on tutorial https://www.youtube.com/watch?v=y69wBS13wwA&ab_channel=Blackthornprod

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;
    public RoomItem roomItemPrefab;
    private List<RoomItem> _roomItemsList = new List<RoomItem>();
    public Transform contentObject;
    public float timeBetweenUpdates = 1.5f;
    private float nextUpdateTime;
    public PhotonView playerPrefab;
    
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {//create room name and set max players to 3
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){MaxPlayers = 3});
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        //display the current room
        PhotonNetwork.LoadLevel("SampleScene");
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        //SceneManager.LoadScene("SampleScene");
        //roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
        UpdateRoomList(roomList);
    }

     void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in _roomItemsList)
        {
            Destroy(item.gameObject);
        }
        
        _roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom =Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(roomName.name);
            _roomItemsList.Add(newRoom);
        }
        {
            
        }
    }

     public void JoinRoom(string roomName)
     {
         PhotonNetwork.JoinRoom(roomName);
     }

     public void onClickLeaveRoom()
     {
         PhotonNetwork.LeaveRoom();
     }

     public override void OnLeftRoom()
     {
         roomPanel.SetActive(false);
         lobbyPanel.SetActive(true);
     }

     public override void OnConnectedToMaster()
     {
         PhotonNetwork.JoinLobby();
     }


}
