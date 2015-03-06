using UnityEngine;
using System.Collections;

public class spec1Move : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public GameObject enemyExplosion;
	public float fireRate;
	public float delay;

	private GameObject target;
	private Transform tarTrans;
	public Transform spec1transform;
	private int rotationSpeed = 2;

	//Completely revamped spec1Move file that takes into account aiming and firing
	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
		target = GameObject.FindWithTag("Player");
		tarTrans = target.transform;
	}

	void Update(){
		//spec1transform.rotation = Quaternion.Lerp (spec1transform.rotation, Quaternion.LookRotation (tarTrans.position - spec1transform.position), rotationSpeed * Time.deltaTime);
		Vector3 point1 = target.transform.position;
		point1.x = 0;
		spec1transform.LookAt(point1);
	}
	
	void Fire ()
	{
		//Quaternion shot1rotate = Quaternion.Euler (0,90,0);
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		shotSpawn.Rotate(15,0,0);
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		shotSpawn.Rotate(-30,0,0);
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		shotSpawn.Rotate(15,0,0);
	}

	/*void OnTriggerEnter(Collider col1){
				if (col1.tag == "Projectile") {
						Instantiate (enemyExplosion, transform.position, transform.rotation);
						Destroy (col1.gameObject);
						Destroy (gameObject);
				}
		}*/
}
