using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject hazard2;
	public Vector3 spawnValues;
	public int hazardCount;
	public int hazardCount2;
	public float spawnWait;
	public float spawnWait2;
	public float startWait;
	public float startWait2;
	public float waveWait;
	public float waveWait2;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		StartCoroutine (SpawnWaves2 ());
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
       		}
        }
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i<hazardCount; i++) {
					Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-6, 6), spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
			}

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	IEnumerator SpawnWaves2 ()
	{
		yield return new WaitForSeconds (startWait2);
		while (true) {
			//yield return new WaitForSeconds (waveWait2);
			for (int i = 0; i<hazardCount2; i++) {
				Vector3 spawnPosition2 = new Vector3 (spawnValues.x, Random.Range (-6, 6), spawnValues.z);
				Quaternion spawnRotation2 = Quaternion.identity;
				Instantiate (hazard2, spawnPosition2, spawnRotation2);
				yield return new WaitForSeconds (spawnWait2);
			}
			/*
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}*/
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

}
