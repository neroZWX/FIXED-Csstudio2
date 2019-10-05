using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using Common;



public class ClientManager : BaseManager
{
    private const string IP = "127.0.0.1";
    private const int Port = 6666;
    private Socket clientSocket;
    private Message msg = new Message();
    public ClientManager(GameFacade gameFacade) : base(gameFacade) { }
    public override void OnInit()    
    {
        base.OnInit();
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, Port);
            Start();
        }
        catch (Exception e)
        {
            Debug.LogWarning("Cannot connecnt the Server, please check you network!"+e);
        }
        
    }
    public void Start() {
        clientSocket.BeginReceive(msg.Data,msg.IndexStart,msg.RemainSize,SocketFlags.None,ReceiveCallBakck,null);
    }
    // listen the server's send status
    private void ReceiveCallBakck(IAsyncResult ar) {
        try {
            int count = clientSocket.EndReceive(ar);
            msg.ReadMessag(count,OnProcessDataCallBack);
            Start();
        }
        catch (Exception e) {
            Debug.Log(e);
        }
        
    }
    private void OnProcessDataCallBack(Request request, string data) {
        //todo
        gamefacde.HandleReponse(request, data);
    }
    // Send message 
    // get data 
    public void SendRequest(Request request, ActionCode actionCode, string data) {
        byte[] bytes = Message.PackData(request, actionCode, data);
        clientSocket.Send(bytes);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();

        try
        {
            clientSocket.Close();
        }
        catch (Exception e)
        {
            Debug.LogWarning("Cannot close the connection!"+e);
        }
    }
}

