using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.AspNetCore.SignalR.Client;
using Unity.VisualScripting;


public class BroadcastService : MonoBehaviour, IInitializable
{

    public Text ReceivedText;
    public InputField MessageInput;
    public Button SendButton;
    
    public const string ServerAddress = "https://localhost:7045";
    private const string Hub = "/UnoHub";

    private static HubConnection _connection;
    public event Action<string> OnMessageReceived;


    // Like Start. It is called before the first frame update
    public async void Initialize()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(ServerAddress + Hub)
            .Build();     

        // Server sends a message
        _connection.On("OnMessageReceived", (string message) => 
        {
            OnMessageReceived?.Invoke(message);
        } );


        await _connection.StartAsync();
    }

    
    public async Task BroadcastMessage(string message){

        await _connection.SendAsync("BroadcastMessage", message);
    }

    public static async Task StartGame(){
        
        Debug.Log(" --- SignalR: Game Started! -- ");
        await _connection.SendAsync("StartGame");
    }

}

