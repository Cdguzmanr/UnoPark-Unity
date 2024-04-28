using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    //A reference to the game manager
	public MenuCamControl menuControl;


	void OnTriggerEnter(Collider other)
	{
        //Debug.Log("-------------- Mount Trigger activated. ----- \nCurrent object: " + this.gameObject.name);

		menuControl.UpdateUI(this.gameObject.name);        

		
	}
}
