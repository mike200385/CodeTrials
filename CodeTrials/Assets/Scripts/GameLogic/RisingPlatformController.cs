using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RisingPlatformController : MonoBehaviour {

	public GameObject risingPlatform;
	public float unit; //test number so that 14 increments makes the water the correct level
	public Text weightText; // text showing weight on platform
	public float sumWeight; // total weight so far
	public SpriteRenderer[] sprites; //used to change color based on weight
	public GameObject desktop; // used for placing the player when test is failed
	Vector3 initialPosition;
	public bool scoreChanged;

	// Use this for initialization
	void Start () {
		unit = 0.35f;
		weightText.enabled = false;
		sumWeight = 0;
		sprites = GetComponentsInChildren<SpriteRenderer> ();
		initialPosition = this.transform.position;
		scoreChanged = false;
		//set color to red for heat
		foreach (SpriteRenderer spr in sprites) {
			spr.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//increase platform height
	void platformUp(int boxWeight){
		float adjust = unit * boxWeight;
		transform.position = new Vector3 (transform.position.x, transform.position.y+adjust, 0); // move water upward
	}
	//decrease platform height
	void platformDown(int boxWeight){
		float adjust = unit * boxWeight;
		transform.position = new Vector3 (transform.position.x, transform.position.y-adjust, 0); // move water downward

	}

	void OnCollisionEnter2D(Collision2D other){
		//enable the text the first time
		weightText.enabled = true;
		if (other.gameObject.CompareTag("ArrayBox")) {
			//print ("Collision detected");
			int wght = other.gameObject.GetComponent<ArrayBoxController> ().getWeight ();
			sumWeight += wght; // increase sum
			//change text
			weightText.text = "Weight Needed: 14 \n Current Weight: " + sumWeight; // change weight
			//move platform up specified amount
			platformUp (wght);

			//check the weight and adjust color if needed
			checkWeightColor ();
		}

		if (other.gameObject.CompareTag ("Player")) {
			if (sumWeight != 14) {
				other.gameObject.transform.position = desktop.transform.position;
			}
		}


	}
	//change color based on the weight
	public void checkWeightColor(){
		if (sumWeight == 14) {
			foreach (SpriteRenderer spr in sprites) {
				spr.color = Color.white;
			}
			//add to score
			if (!scoreChanged) {
				GlobalController.Instance.incScore ();
				scoreChanged = true;
			}
		}
	}

	public void resetPlatformTotally (){
		this.transform.position = initialPosition;
		foreach (SpriteRenderer spr in sprites) {
			spr.color = Color.red;
		}
		sumWeight = 0;
		weightText.text = "Weight Needed: 14 \n Current Weight: " + sumWeight; // change weight

	}



}
