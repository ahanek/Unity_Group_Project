using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    private Text roomName;
    private LobbyManager manager;

    public void SetRoomName(string _roomName)
    {
        GameObject inputFieldGo = GameObject.Find("CreateInputField");
        var inputFieldCo = inputFieldGo.GetComponent<InputField>().text;
        roomName.text = inputFieldCo;
        //roomName.text = _roomName;
    }

    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }

    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
}
