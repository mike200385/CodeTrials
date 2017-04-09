using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class arithmeticTeleporter : MonoBehaviour {

	private bool inArea = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (Input.GetKeyDown ("x")) {
				SceneManager.LoadScene ("ArithmeticLevel");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//show interact text
			inArea = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		inArea = false;
	}
}