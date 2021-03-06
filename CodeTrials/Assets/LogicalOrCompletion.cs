﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalOrCompletion : MonoBehaviour {
	
	//Draggable Tiles and their Replacements, and flag bools
	public ArrayReaction trueSuccess, falseSuccess, orSuccess;
	public ArrayReaction replacementTrue, replacementFalse, replacementOr;
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
	private float rightX = 138f;
	private float leftX = 124f;
	private float inSceneY = -20f;
	private float offScreenY = -100f;

	//Door Starting and Ending Locations

	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		leftPylonFlag = false;
		rightPylonFlag = false;
		scoreChanged = false;

	}

	// Update is called once per frame
	void Update () {
		if (trueSuccess.success && replacementTrue.giveName == "ReplacementTrue") {
			if (!GlobalController.Instance.logicalOrComplete && !puzzleFinished) {
				controlLeft ();
			}
		}

		if (falseSuccess.success && replacementFalse.giveName == "ReplacementTrue") {
			if (!GlobalController.Instance.logicalOrComplete && !puzzleFinished) {
				controlRight ();
			}
		}

		if (orSuccess.success && replacementOr.giveName == "ReplacementOR") {
			if (leftPylonFlag || rightPylonFlag && !doorOpened && trueSuccess.success && falseSuccess.success) {

				puzzleFinished = true;
				if (!camToggled) {
					GlobalController.Instance.toggleCamera ();
					camToggled = true;

				}
				//add to score
				if (!scoreChanged) {
					GlobalController.Instance.incScore ();
					GlobalController.Instance.logicalOrComplete = true;
					scoreChanged = true;
				}
			}
		}
				

		if (Input.GetKeyDown (KeyCode.R) && GlobalController.Instance.camName == "LogicalOrCamera") {
			GlobalController.Instance.logicalOrComplete = false;
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
		trueSuccess.resetSuccessBool ();
		falseSuccess.resetSuccessBool ();
		orSuccess.resetSuccessBool ();
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
