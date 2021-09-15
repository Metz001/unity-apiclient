using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySocketIO;
using UnitySocketIO.Events;


public delegate void EmptyDelegate();
public delegate void MessageDelegate(string mensaje);

public class WebSocketManager : MonoBehaviour
{
    public SocketIOController socket   { get; set; }

    public event MessageDelegate onConnectedToServer;
    public event MessageDelegate onDisconnected;
    public event MessageDelegate onMatchReady;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        socket = gameObject.GetComponent<SocketIOController>();
        initLocalEvents();
        ListenRemoteEvents();

    }

    private void initLocalEvents()
    {
        onConnectedToServer += HandleMessageDelegate;
        onDisconnected += HandleMessageDelegate;
    }

    public void ListenRemoteEvents()
    {
        socket.On("onConnection", onConnected);
        socket.On("disconnect", Disconnect);
        socket.On("matchReady", MatchReady);


    }


    public void ConnectToServer(string token)
    {
        socket.Connect();
    }
    
    
    
    private void onConnected(SocketIOEvent obj)
    {
        MessageData data = JsonUtility.FromJson<MessageData>(obj.data);
        onConnectedToServer(data.msg);

    }

    private void Disconnect(SocketIOEvent obj)
    {
        onDisconnected("");
    }

    private void MatchReady(SocketIOEvent obj)
    {
        MessageData data = JsonUtility.FromJson<MessageData>(obj.data);
        onMatchReady("Match: " + data.match);

    }


    public void FindMatch()
    {
        socket.Emit("findMatch");
    }



    private void RoomCreated(SocketIOEvent obj)
    {
        Debug.Log("Se creo un cuarto");
    }

    public void CreateRoom()
    {

        RoomOptions roomOptions = new RoomOptions(2, 2, "Mi sala");

        socket.Emit("createRoom",JsonUtility.ToJson(roomOptions));
    }

    public void HandleMessageDelegate(string msg )
    {
        Debug.Log(msg);
    }
}

class MessageData
{
    public string msg;
    public string match;
}

class RoomOptions
{
    public int MinPlayers;
    public int MaxPlayers;
    public string Name;

    public RoomOptions(int min, int max, string name)
    {
        MinPlayers = min;
        MaxPlayers = max;
        Name = name;
    }
}
