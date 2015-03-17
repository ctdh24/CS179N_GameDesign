using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

	public GameObject pauseOverlay;

	private int buttonWidth = 200;
	private	int	buttonHeight = 50;
	private int groupWidth = 200;
	private	int	groupHeight = 170;
	bool paused = false;

	//for music
	AudioSource pauseAudio;
	//public GameObject gameObject;
	AudioSource gameAudio;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		pauseAudio = GetComponent<AudioSource> ();
		gameAudio = pauseOverlay.GetComponent<AudioSource> ();

		//Time.timeScale = 1;
	}

	void OnGUI()
	{
		if (paused) {
			GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight));
			if (GUI.Button (new Rect (0, 0, buttonWidth, buttonHeight), "Continue")) {
				paused = togglePaused();
			}
			if (GUI.Button (new Rect (0, 60, buttonWidth, buttonHeight), "Restart Game")) {
					Application.LoadLevel (1);
			}
			if (GUI.Button (new Rect (0, 120, buttonWidth, buttonHeight), "Main Menu")) {
				Application.LoadLevel (0);
			}
			GUI.EndGroup ();
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.P))
			paused = togglePaused();
	}

	bool togglePaused()
	{
		if(Time.timeScale == 0)
		{
			Screen.lockCursor = true;
			Time.timeScale = 1;
			//play one and pause another audio source
			pauseAudio.Play ();
			gameAudio.Pause ();
//			//play one and pause another audio source
//			pauseAudio.Pause ();
//			gameAudio.Play ();

			pauseOverlay.SetActive(false);
			return(false);
		}
		else
		{
			Screen.lockCursor = false;
			Time.timeScale = 0;

//			//play one and pause another audio source
//			pauseAudio.Play ();
//			gameAudio.Pause ();
			//play one and pause another audio source
			pauseAudio.Pause ();
			gameAudio.Play ();

			pauseOverlay.SetActive(true);
			return(true);
		}
	}

}
/*
 * 	AudioSource pauseAudio;
	public GameObject gameObject;
	AudioSource gameAudioe;

	// Use this for initialization
	void Start () {
		pauseAudio = GetComponent<AudioSource> ();
		pauseAudio.Play ();
		gameAudioe = gameObject.GetComponent<AudioSource> ();
		gameAudioe.Pause ();
	}
*/