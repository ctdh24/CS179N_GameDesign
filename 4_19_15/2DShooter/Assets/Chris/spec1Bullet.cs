using UnityEngine;
using System.Collections;

public class spec1Bullet : MonoBehaviour {
//	public float spec1Damage;
//	private float Spec1FireRate = 0.3f;
	//private string spec1name = "Enemy3";
	private float spec1speed = 8.5f;
	public int attackDamage = 25;

	private GameController gameController;
	public GameObject explosion;
	public GameObject playerExplosion;

	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		rigidbody.velocity = transform.forward * spec1speed * 1; //projectile moves left

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if(gameController==null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 8);
	}

	void OnTriggerEnter(Collider target){
		if (target.tag == "Player") {
			Destroy (gameObject);
			
			if(playerHealth.currentHealth > 0)
			{
				playerHealth.TakeDamage (attackDamage);
				
				if(playerHealth.currentHealth <= 0){
					Instantiate (playerExplosion, target.transform.position, target.transform.rotation);
					Destroy (target.gameObject);
					gameController.GameOver();
				}
			}
			
		}


	}
}
