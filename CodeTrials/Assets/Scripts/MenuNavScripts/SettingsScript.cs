using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

	public Slider volumeSlider;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		AudioListener.volume = volumeSlider.value;
	}

	public void toggleFullscreen(){
		Screen.fullScreen = !Screen.fullScreen;
	}
}