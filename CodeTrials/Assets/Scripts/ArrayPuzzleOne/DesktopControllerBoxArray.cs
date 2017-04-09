using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesktopControllerBoxArray : MonoBehaviour {

	public Text prompt; //text to display
	private bool inArea = false;
	public Camera puzzleCamera;
	public Camera mainCam;

	// Use this for initialization
	void Start () {
		prompt.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (Input.GetKeyDown ("x")) {
				GlobalController.Instance.changeSecondCamera (puzzleCamera);
				GlobalController.Instance.toggleCamera ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//show interact text
			prompt.enabled = true;
			inArea = true;
			//zoom out camera for player to see puzzle
			mainCam.orthographicSize = 11.0f;

		}
	}



	void OnTriggerExit2D(Collider2D other){
		prompt.enabled = false;
		inArea = false;
		mainCam.orthographicSize = 6.0f;
	}
}
