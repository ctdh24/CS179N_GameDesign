using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	
	public GameObject enemy;
	public int enemyCount;
	public int totalCount = 0;
	public float spawnWait;
	public float startWait;
	private GameController gameController;
	public float negYrange;
	public float posYrange;
	
	private bool not_over_count = true;
	private Vector3 spawn = new Vector3(0.0f, 0.0f, 25);
	private int currCount = 0;

	private bool gameOver = false;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (not_over_count) {
			//for (int i = 0; i<enemyCount; i++) {
			Vector3 spawnPosition = new Vector3 (spawn.x, Random.Range (negYrange, posYrange), spawn.z);
			for(int i = 0; i<4; i++)
			{
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(0.70f);
			}
			/*
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (enemy, spawnPosition, spawnRotation);

			spawnPosition.x += 1.0f;
			Instantiate (enemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(2);

			spawnPosition.x += 1.0f;
			Instantiate (enemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(2);
			*/
			currCount++;
			yield return new WaitForSeconds (spawnWait);
			//}
			if(currCount >= totalCount) not_over_count = false;

			gameOver = gameController.gameOver;

			if (gameOver == true)
				break;
		}
	}
}