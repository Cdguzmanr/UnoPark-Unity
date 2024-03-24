using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuCamControl : MonoBehaviour
{

    public Transform currentMount;
    public float speedFactor = 0.01f;


    // public Camera[] cameras;
    // private int currentCameraIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //currentMount = 
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

}
