using UnityEngine;
using System.Collections;
using System;

public class spec1Move : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public GameObject enemyExplosion;
	public float fireRate = 0.5f;
	public float delay = 3.0f;
	public float speed = 6f;
	
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
		
		//Enemy starts off screen, and moves to z-position of 12 to set up, then fires at the player
		
		
		
	}
	
	void Update(){
		//spec1transform.rotation = Quaternion.Lerp (spec1transform.rotation, Quaternion.LookRotation (tarTrans.position - spec1transform.position), rotationSpeed * Time.deltaTime);
		try{
			Vector3 point1 = target.transform.position;
			point1.x = 0;
			spec1transform.LookAt(point1);
		}
		catch(Exception e){
			//Debug.LogError ("Exception");
		}
		Vector3 destPoint = new Vector3(0.0f, this.transform.position.y, -12.0f);
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, destPoint, step);

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
	
	void OnTriggerEnter(Collider col1){
		if (col1.tag == "Player") {
			Instantiate (enemyExplosion, transform.position, transform.rotation);
			//Destroy (col1.gameObject);
			Destroy (gameObject);
		}
		if (col1.tag == "BackColider"){
			Destroy	(gameObject);
		}
	}
}