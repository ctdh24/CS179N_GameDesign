using UnityEngine;
using System.Collections;

public class CreditsTrigger : MonoBehaviour {
	
	public GameObject menuCanvas;
	public GameObject creditsCanvas;

	void Start () {
		menuCanvas.SetActive (true);
		creditsCanvas.SetActive (false);
	}
	
	public void toCredits(){
		menuCanvas.SetActive(false);
		creditsCanvas.SetActive(true);
	}
	
	public void backToMenu(){
		menuCanvas.SetActive(true);
		creditsCanvas.SetActive(false);
	}
	
}
