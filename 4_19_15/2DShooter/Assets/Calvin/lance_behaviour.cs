using UnityEngine;
using System.Collections;

public class lance_behaviour : MonoBehaviour {
	private Quaternion rotation;
	private Vector3 currPosition;
	// Use this for initialization
	
	void Awake(){
		rotation = transform.rotation;
	} 
	void Start () {
		currPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 0.001f);
	}
	void LateUpdate(){
		transform.rotation = rotation;
		transform.position = currPosition;
	}
}
