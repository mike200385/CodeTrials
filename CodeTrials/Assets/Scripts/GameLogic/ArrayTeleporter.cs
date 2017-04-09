using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrayTeleporter : MonoBehaviour {

	private bool inArea = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (inArea) {
			if (Input.GetKeyDown ("x")) {
				SceneManager.LoadScene ("ArrayLevel");
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
