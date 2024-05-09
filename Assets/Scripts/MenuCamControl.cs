using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MenuCamControl : MonoBehaviour
{
    // Camera Movement 
    public Control controlInstance;
    public Transform currentMount;
    public float speedFactor = 0.01f;


    // Trigger - UI Canvas Control
    public GameObject mainMenuCanvas;
    public GameObject loginCanvas;
    public GameObject registerCanvas;
    public GameObject playCanvas;
    public GameObject pauseCanvas;
    public GameObject playersCanvas;
    public GameObject winnerCanvas;

    public GameObject[] toggles = new GameObject[4]; // Set the AI Players from Menu

    void Start()
    {
        DeactivateAllCanvas();
        //Debug.Log("Current Camera: " + this.gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moves and rotates the camera to the new view position
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);
    }


    public void SetMount(Transform newMount)
    {
        DeactivateAllCanvas();
        currentMount = newMount;
    }
    
    public void UpdateUI(string UIName){
        if (UIName == "MainMount" && currentMount == GameObject.Find("MainMount").transform){

            DeactivateAllCanvas();
            ActivateCanvas(mainMenuCanvas);

            Debug.Log("Main Menu activated.");
        }
        else if (UIName == "LoginMount" && currentMount == GameObject.Find("LoginMount").transform){
            DeactivateAllCanvas();
            ActivateCanvas(loginCanvas);
            
            Debug.Log("Login Menu activated.");
        } 
        else if (UIName == "RegisterMount" && currentMount == GameObject.Find("RegisterMount").transform)
        {
            DeactivateAllCanvas();
            ActivateCanvas(registerCanvas);

            Debug.Log("Register Menu activated.");
        } 
        else if (UIName == "PlayersMount" && currentMount == GameObject.Find("PlayersMount").transform)
        {
            DeactivateAllCanvas();
            ActivateCanvas(playersCanvas);

            Debug.Log("Players Menu activated.");
        } 

        else if (UIName == "PlayMount" && currentMount == GameObject.Find("PlayMount").transform)
        {
            DeactivateAllCanvas(); 
            ActivateCanvas(playCanvas);
            Debug.Log("Play Interface activated.");
            
            play();
            
        }
    }


    public void ActivateRegisterLogin(){
        if (loginCanvas.activeSelf){
            loginCanvas.SetActive(false);
            registerCanvas.SetActive(true);
        } else {
            registerCanvas.SetActive(false);
            loginCanvas.SetActive(true);
        }
    }

    // Canvas Management -- Show or hide canvas 
        private void ActivateCanvas(GameObject canvas)
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
    }

    private void DeactivateCanvas(GameObject canvas)
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }

    private void DeactivateAllCanvas()
    {
        DeactivateCanvas(mainMenuCanvas);
        DeactivateCanvas(loginCanvas);
        DeactivateCanvas(registerCanvas);
        DeactivateCanvas(playCanvas);
        DeactivateCanvas(pauseCanvas);
        DeactivateCanvas(playersCanvas);
        DeactivateCanvas(winnerCanvas);
        Debug.Log("--- All Canvas Deactivated ---");
    }


    public void GoHome(){
        SetMount(GameObject.Find("MainMount").transform);
    }

    	void OnTriggerEnter(Collider other)
	{
        //Debug.Log("-------------- Camera Trigger activated. ----- \nCurrent object: " + this.tag);
        
	}


    // Game Management -------------------------------------------------------------

    public void play() { //finds the toggle that is on to decide how many ai players there will be
        for (int i = 0; i <= 4; i++) {
            if (toggles[i].GetComponent<Toggle>().isOn) {
                Control.numbOfAI = i+1;
                Debug.Log("Number of AI Players: " + (i+1) );
                break;
            }				
        }
		
    
        // Starts the game  
        controlInstance.StartGame();
        Control.gameStarted = true;
	}
    

}
