using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleporterController : MonoBehaviour {

	public bool inArea;
	public Text prompt; //text to display

	// Use this for initialization
	void Start () {
		inArea = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x") && inArea) {
			//send it the tag, which is also the level name
			GlobalController.Instance.changeScene (this.tag); 
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			inArea = true;
			prompt.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			inArea = false;
			prompt.enabled = false;
		}
	}
		
}