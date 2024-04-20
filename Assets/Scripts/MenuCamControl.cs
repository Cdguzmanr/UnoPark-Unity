using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuCamControl : MonoBehaviour
{
    // Camera Movement 
    public Transform currentMount;
    public float speedFactor = 0.01f;


    // Trigger - UI Canvas Control
    public GameObject mainMenuCanvas;
    public GameObject loginCanvas;
    public GameObject playCanvas;
    public GameObject registerCanvas;


    private bool hasActivated;


    void Start()
    {
        Debug.Log("Current Camera: " + this.gameObject.name);
        
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
        Debug.Log("Menu Camera Control initialized.");

        currentMount = newMount;
        DeactivateCanvas(mainMenuCanvas);
        DeactivateCanvas(loginCanvas);
        DeactivateCanvas(playCanvas);

        Debug.Log("All Canvas Deactivated.");
    }

    public void UpdateUI(string UIName){
        if (UIName == "MainMount"){
            ActivateCanvas(mainMenuCanvas);
            DeactivateCanvas(loginCanvas);
            DeactivateCanvas(playCanvas);
            DeactivateCanvas(registerCanvas);

            Debug.Log("Main Menu activated.");
        }
        else if (UIName == "LoginMount"){
            DeactivateCanvas(mainMenuCanvas);
            ActivateCanvas(loginCanvas);
            DeactivateCanvas(playCanvas);
            DeactivateCanvas(registerCanvas);

            Debug.Log("Login Menu activated.");
        } 
        else if (UIName == "RegisterMount")
        {
            DeactivateCanvas(mainMenuCanvas);
            DeactivateCanvas(loginCanvas);
            DeactivateCanvas(playCanvas);
            ActivateCanvas(registerCanvas);

            Debug.Log("Register Menu activated.");
        }
        else if (UIName == "PlayMount")
        {
            DeactivateCanvas(mainMenuCanvas);
            DeactivateCanvas(loginCanvas);
            ActivateCanvas(playCanvas);
            DeactivateCanvas(registerCanvas);

            Debug.Log("Play Interface activated.");
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

    	void OnTriggerEnter(Collider other)
	{
        Debug.Log("-------------- Camera Trigger activated. ----- \nCurrent object: " + this.tag);


        
	}

}
