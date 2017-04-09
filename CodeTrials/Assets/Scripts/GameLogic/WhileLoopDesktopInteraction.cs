using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhileLoopDesktopInteraction : MonoBehaviour {	
	public Text prompt; //text to display
	private bool inArea = false;
	public Camera mainCam;
	public Camera puzzleCam;
	public bool onMainCam = true;


	// Use this for initialization
	void Start () {
		prompt.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (Input.GetKeyDown ("x")) {
				toggleCamera();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//show interact text
			prompt.enabled = true;
			inArea = true;

		}
	}

	void OnTriggerExit2D(Collider2D other){
		prompt.enabled = false;
		inArea = false;
	}

	public void toggleCamera(){
		if (onMainCam) {
			mainCam.enabled = false;
			puzzleCam.enabled = true;
			onMainCam = !onMainCam;
		}
		else if (!onMainCam) {
			mainCam.enabled = true;
			puzzleCam.enabled = false;
			onMainCam = !onMainCam;
		}
	}
}