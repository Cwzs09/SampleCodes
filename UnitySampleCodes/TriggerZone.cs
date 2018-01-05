using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone : MonoBehaviour {

	public Light doorLight;
	public Text textHints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("entered zone");
		if (col.gameObject.tag == "Player") {
			if (Inventory.charge == 4) {
				
				transform.Find ("door").SendMessage ("DoorCheck");
				if (GameObject.Find ("PowerGUI")) {
					Destroy (GameObject.Find ("PowerGUI"));
					doorLight.color = Color.green;
				}
			} 
			else {
				textHints.SendMessage ("ShowHint", "This door seems locked.. maybe that generator needs power..."); 

			}
		}
	}
}
