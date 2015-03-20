using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	public int bulletDamage;
	public GameObject asteroidhit;
	public GameObject spanwedEnemies;
	public GameObject Player;
	//public Transform spawnPlayer; //source of the weapon

	public int attackDamage;

	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	EnemyHealth enemyHealth;                    // Reference to this enemy's health.

	IEnumerator MyMethod(){
		yield return new WaitForSeconds (1);
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();

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

	void OnTriggerEnter(Collider other){

		if (other.tag != "Player" && other.tag != "Enemy" && other.tag!="BackColider") {
				enemyHealth.TakeDamage (bulletDamage);
				Instantiate (asteroidhit, transform.position, transform.rotation);
				Destroy (other.gameObject);

				if (enemyHealth.currentHealth <= 0) {
					Instantiate (explosion, transform.position, transform.rotation);
					Destroy (gameObject);
					
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate(spanwedEnemies, transform.position, spawnRotation);
			
			}
		}

		if (other.tag == "BackColider") {
				Destroy (gameObject);
		}

		if (other.tag != "Player" && other.tag == "Enemy"){
			/*
			enemyHealth.TakeDamage (bulletDamage);
			Instantiate (asteroidhit, transform.position, transform.rotation);
			Destroy (other.gameObject);

			if (enemyHealth.currentHealth <= 0) {
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}*/
			return;
		}
//		/
//		if (other.tag == "Enemy2") {
//				Destroy (gameObject);
//				Instantiate (explosion, transform.position, transform.rotation);
//		}

		if (other.tag == "Trigger")
			return;

		//Destroy (gameObject);
		if (other.tag == "Player") {

			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

			if(playerHealth.currentHealth > 0)
		    {
				playerHealth.TakeDamage (attackDamage);

				if(playerHealth.currentHealth <= 0){
					Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
					Destroy (other.gameObject);
					gameController.GameOver();
				}
			}

		}
		gameController.AddScore (scoreValue);

	}
}
