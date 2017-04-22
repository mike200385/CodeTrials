using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalAndCompletion : MonoBehaviour {

	//Draggable Tiles and their Replacements, and flag bools
	public ArrayReaction slotOneSuccess, slotTwoSuccess, andSuccess;
	public ArrayReaction replacementTrue, replacementTrueToo, replacementAnd;
	public bool puzzleFinished, camToggled, leftPylonFlag, rightPylonFlag, doorOpened, scoreChanged;
	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots

	//Pylon GameObjects
	public GameObject leftPylonClosed;
	public GameObject rightPylonClosed;
	public GameObject leftPylonRaised;
	public GameObject rightPylonRaised;

	public AudioSource solved, raisePillarSound, raiseDoor;

	//GameObject spawn in locations
	private float rightX = 126f;
	private float leftX = 112f;
	private float inSceneY = 9f;
	private float offScreenY = 48f;

	//Door Starting and Ending Locations

	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		leftPylonFlag = false;
		rightPylonFlag = false;

	}

	// Update is called once per frame
	void Update () {
		if (slotOneSuccess.success && replacementTrue.giveName == "ReplacementTrue") {
			if (!GlobalController.Instance.logicalAndComplete && !puzzleFinished) {
				controlLeft ();
			}
		}

		if (slotTwoSuccess.success && replacementTrueToo.giveName == "ReplacementTrue") {
			if (!GlobalController.Instance.logicalAndComplete && !puzzleFinished) {
				controlRight ();
			}
		}

		if (andSuccess.success && replacementAnd.giveName == "ReplacementAND") {
			if (leftPylonFlag && rightPylonFlag && !doorOpened && slotOneSuccess.success && slotTwoSuccess.success) {

				puzzleFinished = true;
				solved.Play ();
				if (!camToggled) {
					GlobalController.Instance.toggleCamera ();
					GlobalController.Instance.logicalAndComplete = true;
					camToggled = true;
				}
				//add to score
				if (!scoreChanged) {
					GlobalController.Instance.incScore ();
					scoreChanged = true;
				}

			}
		}


		if (Input.GetKeyDown (KeyCode.R) && GlobalController.Instance.camName == "LogicalAndCamera") {
			GlobalController.Instance.logicalAndComplete = false;
			doorOpened = false;
			resetPylon ();
			resetTiles ();
			resetSlots ();
			resetActive ();
			resetCheckValues ();
			camToggled = false;
			puzzleFinished = false;
			leftPylonFlag = false;
			rightPylonFlag = false;
			//Lower Score
			GlobalController.Instance.decAdditive ();
		}
	}

	public void controlLeft(){
		if (!leftPylonFlag) {
			leftPylonRaised.transform.position = new Vector3 (leftX, inSceneY, 0);
			leftPylonFlag = true;
			raisePillarSound.Play ();
			raisePillarSound.loop = false;
		}	
	}

	public void controlRight(){
		if (!rightPylonFlag) {
			rightPylonRaised.transform.position = new Vector3 (rightX, inSceneY, 0);
			rightPylonFlag = true;
			raisePillarSound.Play ();
			raisePillarSound.loop = false;
		}	
	}
		

	public void resetPylon (){
		leftPylonRaised.transform.position = new Vector3 (leftX, offScreenY, 0);
		rightPylonRaised.transform.position = new Vector3 (rightX, offScreenY, 0);
	}

	public void resetCheckValues(){
		slotOneSuccess.resetSuccessBool ();
		slotTwoSuccess.resetSuccessBool ();
		andSuccess.resetSuccessBool ();
	}


	public void resetSlots(){
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		foreach (GameObject repTile in replacementTiles) {
			Destroy (repTile);
		}
	}

	public void resetTiles(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			arrayTiles[i].GetComponent<TileDrag>().onReset();
		}
	}

	public void resetActive(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			arrayTiles[i].gameObject.SetActive(true);
		}
	}
}
