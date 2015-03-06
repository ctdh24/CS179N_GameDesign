using UnityEngine;
using System.Collections;

public class DestroyByContact2 : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	public int attackDamage;

	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	EnemyHealth enemyHealth;                    // Reference to this enemy's health.

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

		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Enemy"){
			return;
		}
		Destroy (gameObject);
		if (other.tag == "Player") {
	
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			gameController.GameOver();

		}
		gameController.AddScore (scoreValue);

	}
}
