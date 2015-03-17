using UnityEngine;
using System.Collections;

public class LevelEnder : MonoBehaviour {
	
	public GameObject colider;
	
	public GUIText levelEndText;

	private bool endofLevel = false;

	public GameObject boss; 
	boss1body bossHealth;

	void Start()
	{
		levelEndText.text = "";
		bossHealth = boss.GetComponent<boss1body> ();

	}
	
	void OnTriggerEnter(Collider other){

		if (other.tag == "player") {
				LevelComplete ();
		}
	}
	
	
	
	public void LevelComplete ()
	{
		if(bossHealth.body_hp < 0){
			levelEndText.text = "Level Complete!";
			endofLevel = true;
		}

	}
	
}
