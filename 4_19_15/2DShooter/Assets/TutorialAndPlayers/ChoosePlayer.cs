using UnityEngine;
using System.Collections;

public class ChoosePlayer : MonoBehaviour {

	public GameObject gameController;
	public GameObject hudCanvas;
	public GameObject Ship1ISS;
	public GameObject Ship2COF;
	public GameObject NumofPlayers;
	public GameObject gameSong;

	void Start(){
		Time.timeScale = 0;
		Screen.lockCursor = false;
		gameController.SetActive(false);
		Ship1ISS.SetActive(false);
		Ship2COF.SetActive(false);
		hudCanvas.SetActive(false);
		NumofPlayers.SetActive (true);
		gameSong.SetActive (false);
	}

	// Use this for initialization
	public void onePlayer () {
		gameController.SetActive(true);
		Ship1ISS.SetActive(true);
		Ship2COF.SetActive (false);
		hudCanvas.SetActive(true);
		NumofPlayers.SetActive (false);
		gameSong.SetActive (true);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	public void twoPlayers () {
		gameController.SetActive(true);
		Ship1ISS.SetActive(false);
		Ship2COF.SetActive(true);
		hudCanvas.SetActive(true);
		NumofPlayers.SetActive (false);
		gameSong.SetActive (true);

		Time.timeScale = 1;
	}
}
