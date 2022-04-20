using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    private GameObject inputFieldGo; /* = GameObject.Find("CreateInputField");*/
    private string textToString; /*= inputFieldGo.GetComponent<InputField>().text;*/
    private LobbyManager manager;

    public void SetRoomName(string _roomName)
    {
        // GameObject inputFieldGo = GameObject.Find("CreateInputField");
        // var inputFieldCoo = inputFieldGo.GetComponent<InputField>().text;

        print("SetRoomName: roomName "+_roomName);
        textToString = _roomName;
        print("SetRoomName: inputField "+textToString);
        //roomName.text = _roomName;
    }

    private void Awake()
    {
        manager = FindObjectOfType<LobbyManager>();
        inputFieldGo = GameObject.Find("CreateInputField");
        textToString = inputFieldGo.GetComponent<InputField>().text;
    }
    
    

    public void OnClickItem()
    {
        // GameObject inputFieldGo = GameObject.Find("CreateInputField");
        // var inputFieldCo = inputFieldGo.GetComponent<InputField>().text;
        // manager.JoinRoom(roomName.text);
        
        print("OnclickItem: inputField "+textToString);
        
        manager.JoinRoom(textToString);
    }
}
