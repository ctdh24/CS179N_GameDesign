using UnityEngine;
using System.Collections;
using System;


//Main body of the boss. Can shoot one asteroid out from its mouth at a set interval; fires very slowly
public class boss1body : MonoBehaviour {

	//GameObjects to keep track of the two arms, since the body can't be damaged until both are gone
	public GameObject arm1;
	public GameObject arm2;

	//provide remaining boss model parts so they can be destroyed when the body is destroyed
	public GameObject uppermouth;
	public GameObject lowermouth;
	public GameObject upperbase;
	public GameObject lowerbase;

	public GameObject boss_shot;
	public Transform boss_shotSpawn;
	public GameObject bossExplosion;
	public float fireRate = 1.0f;
	public float delay = 5.0f;
	public float speed = 3.5f;
	public int body_hp = 750;

	
	//private Transform explosionTransform;
	private Material base_material;
	private Color base_color;

	private bool canDamage = false;


	//Start invokes Fire function and saves base material and color for damage flash
	void Start ()
	{	
		Debug.Log("Transform of body is: " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
		//Invoke Fire to start firing asteroids
		InvokeRepeating ("Fire", delay, fireRate);
		
		
		//saved material and color
		base_material = this.renderer.material;
		base_color = this.base_material.color;
		
	}
	
	void Update(){
		if(arm1 == null && arm2 == null){
			//Debug.Log ("Both arms destroyed");
			canDamage = true;
		}

		//Boss moves to a certain position, where it will stop. Just like the enemies do

		//Vector3 destPoint = new Vector3(0.0f, this.transform.position.y, 12.0f);
		//float step = speed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, destPoint, step);
	}
	
	void Fire ()
	{
		//The boss spits out asteroids
		Vector3 tempLoc = new Vector3(boss_shotSpawn.transform.position.x, UnityEngine.Random.Range(-2.5f, 2.5f), boss_shotSpawn.transform.position.z);
		Instantiate(boss_shot, tempLoc, boss_shotSpawn.rotation);
	}
	
	void OnTriggerEnter(Collider col1){
		if(canDamage == true){
			if (col1.tag == "Projectile" && body_hp > 0) {
				Destroy (col1.gameObject);
				
				body_hp = body_hp - 1;
				//Debug.Log ("Arm HP is: " + arm_hp);
				
				StartCoroutine(collideFlash () );
				
				//Destroy (gameObject);
			}
			else if(col1.tag == "Projectile" && body_hp <= 0){
				//Instantiate (armExplosion, explosionTransform.position, explosionTransform.rotation);
				Instantiate (bossExplosion, transform.position, transform.rotation);
				Destroy (col1.gameObject);
				Destroy(gameObject);
				Destroy (upperbase);
				Destroy (uppermouth);
				Destroy (lowerbase);
				Destroy (lowermouth);
			}
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