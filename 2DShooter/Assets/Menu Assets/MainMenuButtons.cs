﻿using UnityEngine;
using System.Collections;

public class MainMenuButtons: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartGame (){
		Application.LoadLevel("firstlevelscene");
	}

	void ExitGame (){
		Application.Quit ();
	}

}
