using UnityEngine;
using System.Collections;

public class LevelEnder : MonoBehaviour {
	
	public GameObject colider;
	
	public GUIText levelEndText;

	private bool endofLevel = false;
	
	void Start()
	{
		levelEndText.text = "";

	}
	
	void OnTriggerEnter(Collider other){

		if (other.tag == "player") {
				LevelComplete ();
		}
	}
	
	
	
	public void LevelComplete ()
	{
		levelEndText.text = "Level Complete!";
		endofLevel = true;

	}
	
}
