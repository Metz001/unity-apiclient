using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySocketIO;
using UnitySocketIO.Events;



public class WebSocketManager : MonoBehaviour
{
    public SocketIOController socket   { get; set; }

    public event Action<string> onConnectedToServer;
    public event Action onDisconnected;
    public event Action<string> onMatchready;



    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        socket = gameObject.GetComponent<SocketIOController>();

        onConnectedToServer += MessageDelegateHandler;

    }



    public void ConnectToServer(string token,string username)
    {
        socket.settings.token = token;
        socket.settings.username = username;
        socket.Init();

        socket.On("onConnection", onConnected);
        socket.On("disconnect", Disconnect);
        socket.On("matchReady", MatchReady);
        socket.Connect();
    }

    public void FindMatch()
    {
        socket.Emit("findMatch");
    }
    
    private void onConnected(SocketIOEvent obj)
    {
        MessageData data = JsonUtility.FromJson<MessageData>(obj.data);
        onConnectedToServer(data.msg);
        
    }

    private void Disconnect(SocketIOEvent obj)
    {
        Debug.Log("disconnect: "+obj.data);
        onDisconnected?.Invoke();
    }

    private void MatchReady(SocketIOEvent obj)
    {
        MessageData data = JsonUtility.FromJson<MessageData>(obj.data);
        onMatchready?.Invoke(data.msg);
    }

    private void MessageDelegateHandler(string message)
    {
        Debug.Log(message);
    }

}

class MessageData
{
    public string msg;
    public string match;
}
