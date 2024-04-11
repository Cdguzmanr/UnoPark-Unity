using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    //A reference to the game manager

	public MenuCamControl menuControl;
	
	// When an object enters the finish zone, let the
	// game manager know that the current game has ended

        void Start()
    {
        Debug.Log("--------- UI Control ---------- \nmenu control: "+ this.tag );
        
        
    }

	void OnTriggerEnter(Collider other)
	{
        Debug.Log("-------------- Mount Trigger activated. ----- \nCurrent object: " + this.tag);

		menuControl.UpdateUI(this.gameObject.name);        
	}
}
