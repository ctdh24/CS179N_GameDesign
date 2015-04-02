using UnityEngine;
using System.Collections;

public class AudioSlider : MonoBehaviour {

	public float audioPercent = 100f;
	AudioSource audio;
	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
		audio = mainCamera.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void AdjustSound (float newAP) {
		audioPercent = newAP;
		audio.volume = 0.01f * audioPercent;
	}
}
