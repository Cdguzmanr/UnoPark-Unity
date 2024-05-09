using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.AspNetCore.SignalR.Client;
using Unity.VisualScripting;

// --- Extra ?
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;


public class SignalRControl : MonoBehaviour, IInitializable
{

    // Fields ---------------------------

    // API Connection Fields    
    HubConnection hubConnection;
    public const string LocalApiBaseUrl = "https://localhost:7045/api";
    public const string LocalApiHubUrl = "https://localhost:7045/UnoHub";
    
    public const string ServerFullHubAddress = "https://bigprojectapi-300079087.azurewebsites.net/UnoHub";
    
    //public const string ServerAddress = "https://bigprojectapi-300079087.azurewebsites.net/";
    //private const string Hub = "UnoHub";

    // Private Fields
    private static HubConnection _connection;
    string user; 


    public event Action<string> OnMessageReceived;


    // Like Start. It is called before the first frame update
    public async void Initialize()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl(LocalApiHubUrl)
            .Build();     

        // Server sends a message
        // _connection.On("OnMessageReceived", (string message) => 
        // {
        //     OnMessageReceived?.Invoke(message); // If it hits this breakpoint, the Backend works. 
        // } );


        _connection.On<string, string>("ReceiveMessage", (s1, s2) => OnSend(s1, s2));



        await _connection.StartAsync();
    }

    
    public static async Task BroadcastMessage(string message){

        await _connection.SendAsync("BroadcastMessage", message);
    }

    // public async Task ConnectToChannel(string user){

    //     await _connection.SendAsync("ConnectToChannel", user);
    // }

    public static async Task StartGame(){
        
        Debug.Log(" --- SignalR: Game Started! -- ");
        await _connection.SendAsync("StartGame");
       // Debug.Log("Hub Address: " +_connection.());
    }


    // ------------------------------------------------------------------------------------------------------------

    public void ConnectToChannel(string user)
    {
        //Start();
        string message = user + " Connected";

        try
        {
            _connection.InvokeAsync("SendMessage", "System", message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

        private void OnSend(string user, string message)
        {
            Console.WriteLine(user + ": " + message);
        }


    /********************************************************************
    private async void InitializeSignalRConnection()
    {
        // Initialize the SignalR connection
        hubConnection = new HubConnectionBuilder()
            .WithUrl(LocalApiBaseUrl + "BattleshipHub", options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(App.CurrentUser.Id.ToString());
            })
            .AddNewtonsoftJsonProtocol() // This line configures the client to use Newtonsoft.Json
            .Build();
        hubConnection.Closed += async (error) =>
        {
            await Task.Delay(new System.Random().Next(2000, 5000));
            await hubConnection.StartAsync();
        };

        hubConnection.On<string, string, int, Guid>("StartGame", (player1, player2, playerTurn, gameID) =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (!App.IsSinglePlayer)
                {
                    var player1Id = Guid.Parse(player1);
                    var player2Id = Guid.Parse(player2);
                    game.Id = gameID;
                    playerBoard.gameId = game.Id;
                    playerBoard2.gameId = game.Id;
                    game.start_time = DateTime.Now;
                    if (App.CurrentUser.Id == player1Id)
                    {
                        playerBoard.userId = player1Id;
                        playerBoard.opponentId = player2Id;
                        playerBoard2.userId = player2Id;
                        game.CurrentPlayerTurn = App.CurrentUser.Id;
                        PlayerTurnInfo.Text = "Your Turn!";
                        PostPlayerBoard1();
                    }
                    else
                    {
                        playerBoard.userId = player2Id;
                        playerBoard.opponentId = player1Id;
                        playerBoard2.userId = player1Id;
                        game.CurrentPlayerTurn = player2Id;
                        PlayerTurnInfo.Text = "Opponent's Turn!";
                        PostPlayerBoard1(true);
                    }
                    App.GameStarted = true;
                    GetGameData();
                }
            });
        });

        // Handle the "ReceiveTurn" event
        hubConnection.On<Guid, Guid, int[,]>("ReceiveTurn", async (userId, gameId, gameBoard) =>
        {
            // This code runs when a "ReceiveTurn" message is received
            // Note: If you need to update the UI, make sure to do it on the UI thread
            await Application.Current.Dispatcher.Invoke(async () =>
            {
                //Code here to avoid cross-threading issues
                GetGameData();
                game.CurrentPlayerTurn = App.CurrentUser.Id;
                App.GameStarted = true;
                PlayerTurnInfo.Text = "Your Turn!";
                UpdateCellColorsA();
                UpdateCellColorsB();
            
                sunk1 = await CheckSunkShips(playerBoard.gameId, playerBoard.userId);
                sunk2 = await CheckSunkShips(playerBoard2.gameId, playerBoard2.userId);

                IsGameOver();
            });
        });

        // Start the connection
        try
        {
            await hubConnection.StartAsync();
        }
        catch (Exception ex)
        {
            // Log the exception or show a message to the user
            MessageBox.Show($"Error starting SignalR connection: {ex.Message}");
        }

    }
    */





}

