using UnityEngine;
using System.Collections;

public class SoundStart : MonoBehaviour {
	
	AudioSource audioToPlay;
	public GameObject gameObject;
	AudioSource audioToPause;

	// Use this for initialization
	void Start () {
		audioToPlay = GetComponent<AudioSource> ();
		audioToPlay.Play ();
		audioToPause = gameObject.GetComponent<AudioSource> ();
		audioToPause.Pause ();
	}

}
