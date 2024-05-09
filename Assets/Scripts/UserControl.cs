using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class UserControl : MonoBehaviour
{

    public GameObject loginUserName;
    public GameObject loginPassword;
    public GameObject registerFirsName;
    public GameObject registerLastName;
    public GameObject registerPassword;
    public GameObject registerConfirmPassword;

    public static UserControl instance;

    public static User user_Instance;

    // Default Methods:
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // API Functionality ----------
    private const string BASE_URL = @"https://bigprojectapi-300079087.azurewebsites.net/";

    // Example methods for different API endpoints

    public IEnumerator Login(string username, string password, Action<bool> callback)
    {
        user_Instance = GetComponent<User>();


        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest request = UnityWebRequest.Post(BASE_URL, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            callback(true);
        }
        else
        {
            Debug.LogError("Login failed: " + request.error);
            callback(false);
        }
    }

    public IEnumerator Register(string firstname, string lastname, string username, string password, string confirmPassword, Action<bool> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest request = UnityWebRequest.Post(BASE_URL, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            callback(true);
        }
        else
        {
            Debug.LogError("Registration failed: " + request.error);
            callback(false);
        }
    }

    public IEnumerator GetUser(Guid id, Action<User> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(BASE_URL + "/" + id.ToString());
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            User user = JsonUtility.FromJson<User>(request.downloadHandler.text);
            callback(user);
        }
        else
        {
            Debug.LogError("Failed to get user: " + request.error);
            callback(null);
        }
    }

    // Other methods for Update, Delete, etc., following a similar pattern

    [Serializable]
    public class User
    {
        public Guid id;
        public string username;
        // Add other user properties here as needed
    }
}