using UnityEngine;
using System.Collections;

public class player_controls : MonoBehaviour {
	public weapon_collection list;
	public Transform model;
	private int score;
	Vector3 currPosition;
	Quaternion rotation;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	void Awake(){
		rotation = transform.rotation;
	}
	
	void LateUpdate(){
		transform.rotation = rotation;
		transform.position = currPosition;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			if (transform.position.y <= 6.5){
				transform.position += transform.up * 15.0f * Time.deltaTime;

				currPosition = transform.position;
			}
			//transform.Rotate (0, Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (KeyCode.S)) {
			if (transform.position.y >= -6.5){
				transform.position += transform.up * -15.0f * Time.deltaTime;
			
				currPosition = transform.position;
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			if (transform.position.z >= -6.5){
				transform.position += transform.forward * -15.0f * Time.deltaTime;

				currPosition = transform.position;
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if (transform.position.z <= 12.5){
				transform.position += transform.forward * 15.0f * Time.deltaTime;

				currPosition = transform.position;
				
			}
		}
		/*
		if (Input.GetKey (KeyCode.N)) {
			//nextFire = 0;
			if (Time.time > nextFire) {
				float tmp_nextFire = Time.time + weapontypes.activeFiringRate ();
				weapontypes.useSelectedWeapon();
				Debug.Log((int)tmp_nextFire);
				nextFire = tmp_nextFire;
				//audio.Play();
			}
		}
		if (Input.GetKey (KeyCode.M)) {
			model.animation.Play();
		}
		model.animation["Take 001"].speed = 3.0f;
	*/
	}
}

