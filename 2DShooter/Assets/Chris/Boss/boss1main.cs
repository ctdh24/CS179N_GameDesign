using UnityEngine;
using System.Collections;



//*****************
//NOTE: This script is only used to move the ENTIRE boss (body + arms) into position
//*****************


public class boss1main : MonoBehaviour {
	//public float boss_hp = 100.0f;
	public float delay = 3.0f;
	public float speed = 10.0f;
	
	private GameObject target;
	private Transform tarTrans;
	//public Transform spec1transform;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 destPoint = new Vector3(0.0f, 0.0f, 9.5f);
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, destPoint, step);

		/*if(boss_hp <= 0.0f){
			Destroy (this.gameObject);
		}*/
	}

	/*void OnTriggerEnter(Collider target){
		if (target.tag == "Projectile") {
			//Instantiate (enemyExplosion, transform.position, transform.rotation);
			boss_hp = boss_hp - 5.0f;
			//Destroy (gameObject);
		}
	}*/

}
