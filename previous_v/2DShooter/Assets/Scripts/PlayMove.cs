using UnityEngine;
using System.Collections;

public class PlayMove : MonoBehaviour {
	public weapon_types weapontypes;
	private float nextFire;
	Quaternion rotation;
	Vector3 currPosition;
	public GameObject model;
	private int score;
	/*Global Variables
	double top_max = 3.5;
	double bottom_max = -3.5;
	double left_max = -6;
	double right_max = 4.5;
	*/

	void Start () {
		score = 0;
	}
	void Awake()
	{
		rotation = transform.rotation;
	}
	
	void LateUpdate()
	{
		transform.rotation = rotation;
		transform.position = currPosition;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			if (transform.position.y <= 6.5){
				transform.position += transform.up * 10.0f * Time.deltaTime;
				currPosition = transform.position;
			}
			//transform.Rotate (0, Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (KeyCode.S)) {
			if (transform.position.y >= -6.5){
				transform.position += transform.up * -10.0f * Time.deltaTime;
				currPosition = transform.position;
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			if (transform.position.z >= -6.5){
				transform.position += transform.forward * -10.0f * Time.deltaTime;
				currPosition = transform.position;
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if (transform.position.z <= 14.5){
				transform.position += transform.forward * 10.0f * Time.deltaTime;
				currPosition = transform.position;
			}
		}
		if (Time.time > nextFire) {
			if (Input.GetMouseButton(0) && !Input.GetMouseButton(1)) {
				nextFire = Time.time + weapontypes.activeFiringRate ();
				weapontypes.useSelectedWeapon();
				//audio.Play();

			}
		}
		if (!Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
			model.animation.Play();
		}
		model.animation["Take 001"].speed = 3.0f;

	}

}
