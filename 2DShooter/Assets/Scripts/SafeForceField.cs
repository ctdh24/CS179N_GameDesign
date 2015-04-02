using UnityEngine;
using System.Collections;

public class SafeForceField : MonoBehaviour {

	void OnTriggerEnter(Collider other){		
		if (other.tag != "Boss" && other.tag!= "Player"){
			Destroy (other.gameObject);
		}
	}
}
