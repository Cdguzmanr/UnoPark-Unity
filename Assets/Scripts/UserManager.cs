using UnityEngine;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.Text;


public class UserManager : MonoBehaviour
{
    // GameObfect Fields:
    public TMP_InputField LoginUserName;
    public TMP_InputField LoginPassword;
    public Button loginButton;
    

    // API Fields
    private const string ApiBaseUrl = "https://localhost:7045/";

    private HttpClient httpClient;


    // General Fields
    public UserLoginDto userData = null;
    public bool isLoggedIn = false;
    public PopUpManager popUpManager;

    // Methods -----------------------------
    private void Start()
    {
        httpClient = new HttpClient();
        loginButton.onClick.AddListener(OnLoginButtonClick);
        Debug.Log("************* User Manager Started ********");
    }



    private void OnLoginButtonClick()
    {
        // Call the LoginUser method from ApiManager using the text values from input fields
        Task<bool> loginTask = LoginUser(LoginUserName.text, LoginPassword.text);
        //Task<bool> loginTask = LoginUser("bfoote", "maple");
        // I can await the task if needed
        //await loginTask;
        
        //Debug.Log("--- Login Button Clicked");
    }    

    


    // Method to login a user
    public async Task<bool> LoginUser(string username, string password)
    {
        Debug.Log("-- Starting User Login: " + username + " | " + password);
        try
        {
            if (userData == null ){
                userData = new UserLoginDto(username, password);
            } else {
                userData.Username = username;
                userData.Password = password;
            }           
            
            //Debug.Log("Login Data: " + loginData.ToString());
            string json = JsonConvert.SerializeObject(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json"); 
            var response = await httpClient.PostAsync(ApiBaseUrl + "api/user/login", content);

            //Debug.Log("response: " + response.StatusCode);
            response.EnsureSuccessStatusCode(); // Throw if not success

            // Login was successful
            string Message = "Login Succesful";
            Debug.Log(Message);
            popUpManager = new PopUpManager(Message);
            
            return true;
        }
        catch (Exception ex)
        {
            string Message = "Login failed: " + ex.Message;
            popUpManager = new PopUpManager(Message);

            Debug.LogError(Message);
            return false;
        }
    }
    
    // Method to logout a user
    public async Task<bool> LogoutUser()
    {
        try
        {
            //Debug.Log("Login Data: " + loginData.ToString());
            string json = JsonConvert.SerializeObject(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json"); 
            var response = await httpClient.PostAsync(ApiBaseUrl + "api/user/logout", content);

            response.EnsureSuccessStatusCode(); // Throw if not success

            // Logout was successful
            Debug.Log("Logout successful");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError("Logout failed: " + ex.Message);
            return false;
        }
    }

/*
    // Method to insert a new user
    public async Task<bool> InsertUser(string username, string password)
    {
        try
        {
            var userData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            var response = await httpClient.PostAsync(ApiBaseUrl + "api/user", userData);
            response.EnsureSuccessStatusCode(); // Throw if not success

            // User insertion was successful
            Debug.Log("User inserted successfully");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError("User insertion failed: " + ex.Message);
            return false;
        }
    }

    private void OnDestroy()
    {
        httpClient.Dispose(); // Dispose the HttpClient instance when not needed anymore
    }
    */
}
