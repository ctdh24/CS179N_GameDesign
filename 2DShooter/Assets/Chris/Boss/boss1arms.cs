using UnityEngine;
using System.Collections;
using System;

public class boss1arms : MonoBehaviour {

	public GameObject boss_shot;
	public Transform boss_shotSpawn;
	public GameObject armExplosion;
	public float fireRate = 0.5f;
	public float delay = 3.0f;
	public float speed = 3.5f;
	public int arm_hp = 20;
	
	private GameObject boss_target;
	private Transform bossTargetTrans;
	public Transform armObject;

	private Vector3 explosionLoc;
	private Quaternion shotRotation = Quaternion.identity;
	private Material base_material;
	private Color base_color;

	//private int rotationSpeed = 2;

	//Start invokes Fire function and saves base material and color for damage flash
	void Start ()
	{
		//Debug.Log("Transform of arm is: " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
		//armTransform.position = new Vector3(0,0,3);


		//ignore the two below statements. they don't work, but i'm leaving them here as reference
		//armTransform.position.y = armObject.position.y + 4;
		//armTransform.position.z = armObject.position.z - 3;

		//saved player position for targeting
		InvokeRepeating ("Fire", delay, fireRate);
		boss_target = GameObject.FindWithTag("Player");
		bossTargetTrans = boss_target.transform;
		

		//saved material and color
		base_material = this.renderer.material;
		base_color = this.base_material.color;

		//explosionTransform.rotation = Quaternion.identity;
		
	}
	
	void Update(){
		float base_y = transform.position.y;
		float base_z = transform.position.z;

		if(transform.position.y > 0.0f){
			explosionLoc = new Vector3(0.0f, base_y + 3.1f, base_z - 5.0f);
		}
		else{
			explosionLoc = new Vector3(0.0f, base_y - 3.1f, base_z - 5.0f);
		}


		try{
			Vector3 point1 = boss_target.transform.position;
			point1.x = 0;

			Vector3 directionVector = (point1 - explosionLoc).normalized;
			shotRotation = Quaternion.LookRotation(directionVector);

			//armObject.LookAt(point1);
		}
		catch(Exception e){
			//Debug.LogError ("Exception");
		}
		//Vector3 destPoint = new Vector3(0.0f, this.transform.position.y, 12.0f);
		//float step = speed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, destPoint, step);
	}
	
	void Fire ()
	{
		//Quaternion shot1rotate = Quaternion.Euler (0,90,0);
		//shotRotation.Set (shotRotation.x + 10, shotRotation.y, shotRotation.z, shotRotation.w);
		Instantiate(boss_shot, explosionLoc, shotRotation);
		//boss_shotSpawn.Rotate(-20,0,0);
		//shotRotation.Set (shotRotation.x -20, shotRotation.y, shotRotation.z, shotRotation.w);
		//Instantiate(boss_shot, explosionLoc, shotRotation);
		//shotRotation.Set (shotRotation.x + 10, shotRotation.y, shotRotation.z, shotRotation.w);
		//boss_shotSpawn.Rotate (10,0,0);
	}

	void OnTriggerEnter(Collider col1){
		if (col1.tag == "Projectile" && arm_hp > 0) {
			Destroy (col1.gameObject);

			arm_hp = arm_hp - 1;
			//Debug.Log ("Arm HP is: " + arm_hp);

			StartCoroutine(collideFlash () );

			//Destroy (gameObject);
		}
		else if(col1.tag == "Projectile" && arm_hp <= 0){
			//Instantiate (armExplosion, explosionTransform.position, explosionTransform.rotation);
			Instantiate (armExplosion, explosionLoc, Quaternion.identity);
			Destroy (col1.gameObject);
			Destroy(gameObject);
		}
	}

	IEnumerator collideFlash() {
		//Debug.Log("collideFlash is called");
		this.renderer.material = null;
		this.renderer.material.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		this.renderer.material = base_material;
		this.renderer.material.color = base_color;
	}
}
