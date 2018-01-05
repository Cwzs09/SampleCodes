using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public static int charge;
	public AudioClip collectSound;
	bool haveMatches = false;

	public Texture2D[] hudCharge;
	public UnityEngine.UI.RawImage chargeHUDGUI;

	// Use this for initialization
	void Start () {
		charge = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CellPickup()
	{
		AudioSource.PlayClipAtPoint (collectSound, transform.position);
		charge++;
		chargeHUDGUI.texture = hudCharge [charge];
	}

	void MatchPickup()
	{
		haveMatches = true;
		AudioSource.PlayClipAtPoint (collectSound, transform.position);
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.name == "campfire" && haveMatches == true) {
			LightFire (GetComponent<Collider> ().gameObject);
		}
	}

	void LightFire (GameObject campfire)
	{
		ParticleSystem fireEmitter;
		fireEmitter = GameObject.Find("FireSystem").GetComponent<ParticleSystem>();



			ParticleSystem.EmissionModule em = fireEmitter.emission;
			em.enabled = true;


		campfire.GetComponent<AudioSource>().Play ();
	}

}
