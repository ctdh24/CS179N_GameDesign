using UnityEngine;
using System.Collections;

public class PlayMove : MonoBehaviour {
	public weapon_types weapontypes;
	private float nextFire;
	Quaternion rotation;
	Vector3 currPosition;
	void Start () {
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
			transform.position += transform.up * 10.0f * Time.deltaTime;
			currPosition = transform.position;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += transform.up * -10.0f * Time.deltaTime;
			currPosition = transform.position;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += transform.forward * -10.0f * Time.deltaTime;
			currPosition = transform.position;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.forward * 10.0f * Time.deltaTime;
			currPosition = transform.position;
		}
		if (Time.time > nextFire) {
			if (Input.GetMouseButton (0) || Input.GetKey (KeyCode.Space)) {
				nextFire = Time.time + weapontypes.activeFiringRate ();
				weapontypes.useSelectedWeapon();
			}
		}

	}
}
