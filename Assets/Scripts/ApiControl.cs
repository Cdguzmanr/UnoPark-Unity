using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiControl : MonoBehaviour
{
    // Fields
    private string baseURL = "https://bigprojectapi-300079087.azurewebsites.net/api/"; 
    public string className = "";





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public User user; 

    IEnumerator GetData(){
        using (UnityWebRequest request = UnityWebRequest.Get(baseURL)){
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError){
                Debug.LogError(request.error); 

            }else {               
                

                string json = request.downloadHandler.text;

                //SimpleJSON.JSONNode stats = XmlSchemaSimpleContent.JSON.Parse(json);
                //SimpleJSON.JSONNode stats =   
            }



        }
    }


}
