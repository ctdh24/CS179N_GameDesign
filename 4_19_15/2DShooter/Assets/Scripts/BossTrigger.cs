using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour {

//	public GameObject stopAsteroids;
//	public GameObject stopEnemies;
	public GameObject spawnBoss;
	GameObject gamecontroller;
	public AudioSource songToPause;

	public GameObject gameSong;

	IEnumerator MyMethod(){
		yield return new WaitForSeconds (20f);
		bossStart ();

	}

	// Use this for initialization
	void Start () {
		StartCoroutine (MyMethod ());
		gamecontroller = GameObject.FindGameObjectWithTag ("GameController");
		songToPause = gamecontroller.GetComponent<AudioSource>();
		StartCoroutine (MyMethod ());
//		bossStart ();

	}
	
	// Update is called once per frame
	void bossStart(){

		Destroy(gameObject);
		gameSong.SetActive(false);
		spawnBoss.SetActive(true);
		songToPause.Pause();

	}


}
