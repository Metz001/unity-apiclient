using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectCtrl : MonoBehaviour
{
    WebSocketManager ws;

    void Start()
    {
        string token = PlayerPrefs.GetString("token");
        string username = PlayerPrefs.GetString("username");

        if(token == null || token == "")
        {
            //Return Login
        }


        ws = GameObject.Find("SocketIO").GetComponent<WebSocketManager>();

        
        ws.onConnectedToServer += OnConnectedToServer;
        ws.onDisconnected += OnDisconnected;
        ws.onMatchready += OnMatchReady;
        ws.ConnectToServer(token,username);


    }

    private void OnMatchReady(string msg)
    {
        Debug.Log(msg);
    }

    public void FindMatch()
    {
        ws.FindMatch();
    }

    private void OnConnectedToServer(string mensaje)
    {
        GameObject.Find("statusText").GetComponent<Text>().text = "Online";
    }
    
    private void OnDisconnected()
    {
        GameObject.Find("statusText").GetComponent<Text>().text = "Offline";

    }

}
