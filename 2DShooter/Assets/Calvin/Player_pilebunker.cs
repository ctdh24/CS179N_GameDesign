using UnityEngine;
using System.Collections;

public class Player_pilebunker : MonoBehaviour {
	public GameObject model;
	public Transform lance_origin;
	public GameObject energylance;

	private bool activate;
	private bool lance_spawn;

	Vector3 currPosition;
	Quaternion rotation;


	// Use this for initialization
	void Start () {
		activate = false;
	}

	// Update is called once per frame
	void instantiateLance(){
		if (lance_spawn == true) { 
			GameObject energyLance_sprite = (GameObject)Instantiate (energylance, lance_origin.position, lance_origin.rotation);
		}
	}

	void Update () {
	  if (Input.GetKeyDown (KeyCode.M) && activate == false) { 
		animation.Play("extrude");
			model.animation["extrude"].speed = 3.0f;
		activate = true;
	  }
	  else if (Input.GetKeyDown (KeyCode.M) && activate == true){
		animation.Play("retract");
			model.animation["retract"].speed = 3.0f;
	    activate = false;
	  }
		if (activate == true) {
			lance_spawn = true;
			instantiateLance ();
		}
	}

}
