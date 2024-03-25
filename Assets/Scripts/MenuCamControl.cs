using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuCamControl : MonoBehaviour
{

    public Transform currentMount;
    public float speedFactor = 0.01f;

    // Trigger 
    public GameObject startCamera;
    public GameObject playCamera;

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
        currentMount = newMount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !hasActivated)
        {
            startCamera.SetActive(false);
            playCamera.SetActive(true);
            hasActivated = true;

            Debug.Log("Camera switch triggered! StartCamera deactivated. PlayCamera activated.");
        }
    }

}
