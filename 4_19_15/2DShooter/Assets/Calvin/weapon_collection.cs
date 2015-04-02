using UnityEngine;
using System.Collections;

public class weapon_collection : MonoBehaviour {

	public GameObject laser;
	public int Laser_damage;
	public int Laser_speed;
	public float laser_ROF;

	public GameObject boomLaser;
	public int boom_damage;
	public int boom_speed;
	public float boom_ROF;

	public GameObject boomLaser1;
	public int boom_damage1;
	public int boom_speed1;
	public float boom_ROF1;

	public Transform weapon_origin;

	public struct ammo{
		public GameObject Laser;
		public int damage;
		public int type_of_ammo;
		public int speed;
		public float ROF;
	}
	public ammo type_one;
	public ammo type_two;
	public ammo type_three;

	private int ammo_type;
	private bool change;
	private int bullet_count;
	private float next_fire; 
	// Use this for initialization
	

	void Start () {
		ammo_type = 0;
		bullet_count = 0;
		type_one.Laser = laser; type_one.damage = Laser_damage; type_one.speed = Laser_speed; type_one.ROF = laser_ROF; type_one.type_of_ammo = 0;
		type_two.Laser = boomLaser; type_two.damage = boom_damage; type_two.speed = boom_speed; type_two.ROF = boom_ROF; type_two.type_of_ammo = 1;
		type_three.Laser = boomLaser1; type_three.damage = boom_damage1; type_three.speed = boom_speed1; type_three.ROF = boom_ROF1; type_three.type_of_ammo = 2;

	}
	

	// Update is called once per frame
	void shoot_laser(){
		if (ammo_type == 0) {
		    GameObject projectile = (GameObject)Instantiate (type_one.Laser, weapon_origin.position, weapon_origin.rotation);
		    projectile.rigidbody.velocity = transform.forward * type_one.speed;
		}
		else if(ammo_type == 1){
			GameObject projectile = (GameObject)Instantiate( type_two.Laser, weapon_origin.position, weapon_origin.rotation);
			projectile.rigidbody.velocity = transform.forward * type_two.speed;
		}
	}
	
	void Update () {
		if (Time.time > next_fire) {
		    if (Input.GetKeyDown(KeyCode.N)) {
				if(ammo_type == 0) InvokeRepeating("shoot_laser", 0f, 1f/type_one.ROF);
				else if(ammo_type == 1) InvokeRepeating("shoot_laser", 0f, 1f/type_two.ROF);
				Debug.Log((int)next_fire);
				//audio.Play();
			}
		}
		if(Input.GetKeyUp(KeyCode.N)) CancelInvoke();

		if (Input.GetKeyDown ("l")) change = true;

		if (Input.GetKeyUp ("l") && change) {
			change = false;
			if(ammo_type == 1){
				ammo_type = 0;
				Debug.Log(ammo_type);
			}
			else if (ammo_type == 0){
				ammo_type = 1;
				Debug.Log(ammo_type);
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player" && other.tag == "Projectile") return;
		if (ammo_type == 1 && (other.tag == "Enemy" || other.tag == "Enemy2" || other.tag == "Enemy3")) {
			GameObject projectile = (GameObject)Instantiate (type_three.Laser, weapon_origin.position, weapon_origin.rotation);
			projectile.rigidbody.velocity = transform.forward * type_three.speed;
		}

	}
}
