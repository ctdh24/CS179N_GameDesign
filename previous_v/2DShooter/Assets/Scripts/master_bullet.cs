using UnityEngine;
using System.Collections;

public class master_bullet : MonoBehaviour {
	public float damage;
	public float fireRate;
	private string creator;
	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 2);
	}
	public void isCreator( string name ) {
		creator = name;
	}
	void OnTriggerEnter( Collider target ) {
		if (target.name == "Enemy" && creator == "Player") {

		}
	}
	public float FireRate() {
		return fireRate;
	}
}
