using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserSoundScript : MonoBehaviour {

	public bool inArea;
	public AudioSource laser;
	public CompletionScriptFour turnOff;

	// Use this for initialization
	void Start () {
		inArea = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (turnOff.laserOff) {
			laser.Stop ();
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && !turnOff.laserOff) {
			inArea = true;
			laser.Play ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			inArea = false;
			laser.Stop ();
		}
	}

}
