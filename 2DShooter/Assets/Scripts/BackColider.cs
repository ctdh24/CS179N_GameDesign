using UnityEngine;
using System.Collections;

public class BackColider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other){
			Destroy (other.gameObject);

		if(other.tag != "Player")
		{
			Destroy (other.gameObject);
		}
	}
}
