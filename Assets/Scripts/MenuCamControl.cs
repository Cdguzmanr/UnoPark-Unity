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


    private bool hasActivated;


    void Start()
    {
        Debug.Log("Current Camera: Start Camera" );
        
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






    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainMount"))
        {
            ActivateCanvas(mainMenuCanvas);
            DeactivateCanvas(loginCanvas);
            DeactivateCanvas(playCanvas);

            Debug.Log("Main Menu activated.");
        }
        else if (other.CompareTag("LoginMount"))
        {
            DeactivateCanvas(mainMenuCanvas);
            ActivateCanvas(loginCanvas);
            DeactivateCanvas(playCanvas);

            Debug.Log("Login Menu activated.");
        }
        else if (other.CompareTag("PlayMount"))
        {
            DeactivateCanvas(mainMenuCanvas);
            DeactivateCanvas(loginCanvas);
            ActivateCanvas(playCanvas);

            Debug.Log("Login Menu activated.");
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

}
