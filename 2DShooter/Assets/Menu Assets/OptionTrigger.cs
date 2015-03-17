using UnityEngine;
using System.Collections;

public class OptionTrigger : MonoBehaviour {

	public GameObject menuCanvas;
	public GameObject optionCanvas;
	bool optionClicked = false;

	void Start () {
//		menuCanvas = GameObject.FindGameObjectWithTag ("MenuCanvas");
//		optionCanvas = GameObject.FindGameObjectWithTag ("OptionCanvas");
		optionCanvas.SetActive (false);
	}

	public void toOption(){
		menuCanvas.SetActive(false);
		optionCanvas.SetActive(true);
	}

	public void backToMenu(){
		menuCanvas.SetActive(true);
		optionCanvas.SetActive(false);
	}
	
}
