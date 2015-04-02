using UnityEngine;
using System.Collections;

public class weapon_types : MonoBehaviour {
	public Transform weapon_source; //source of the weapon

	public GameObject[] weaponList; //array of weapon types
	private int w_list_index;
	private float activeFireRate;
	// Use this for initialization
	void Start () {
		w_list_index = 0;
		master_bullet weapon = weaponList [w_list_index].GetComponent<master_bullet> ();
		activeFireRate = weapon.FireRate ();
		print (weaponList.Length);
	}
	public void useSelectedWeapon(){
		if (weapon_source) {
			GameObject projectile = (GameObject)Instantiate( weaponList[w_list_index], weapon_source.position, weapon_source.rotation);
			projectile.GetComponent<master_bullet>().isCreator("Player");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	public float activeFiringRate( ) {
		return activeFireRate;
	}
}
