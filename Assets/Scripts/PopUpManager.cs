using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{


    public GameObject PopUpOk;
    public Text PopUpText;    
    public Button btnOk;



    // Start is called before the first frame update
    void Start()
    {
        PopUpOk.SetActive(false);
        Debug.Log(" **** PopUp Ok Deactivated **** ");
        btnOk.onClick.AddListener(OnOkClick);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PopUpManager(string Message){
        Debug.Log("New Pop Up: " + Message);
        ShowPopUpOk(Message);
    }

    public void ShowPopUpOk(string Message)
    {
        Debug.Log("PopUp Ok Called");
        PopUpOk.SetActive(true);
        PopUpText.text = Message;
        Debug.Log(" **** PopUp Ok Activated **** ");
    }

    public void OnOkClick()
    {
        PopUpOk.SetActive(false);
        
        Debug.Log(" **** PopUp Ok Deactivated **** ");
    }

    
}
