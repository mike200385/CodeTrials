using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ArithCompletionCheck : MonoBehaviour {

	// LEVEL MANAGER FOR THE ARRAY LEVEL

	public GameObject[] checkSlots;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles;

	public GameObject door;
	Vector3 initialDoorPosition;

	public bool puzzleFinished, camToggled, scoreChanged;
	// Use this for initialization
	void Start () {
		//checkSlots = GameObject.FindGameObjectsWithTag ("InsertSlot");
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
		initialDoorPosition = door.transform.position;
	}

	// Update is called once per frame
	void Update () {
		//if all 5 spots are filled
		if (checkInputSuccess () && checkInputName ()) {
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
				//open the door
				openDoor ();
				puzzleFinished = true;

				//add to score
				if (!scoreChanged) {
					GlobalController.Instance.incScore ();
					scoreChanged = true;
				}
			}

		} else if (checkInputSuccess ()) {
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
				puzzleFinished = true;
			}
		}
		//reset puzzle and platforms
		if (Input.GetKeyDown(KeyCode.R)) {
			//GlobalController.Instance.resetBoxBools();
			resetTiles ();
			resetSlots ();
			resetActive ();
			closeDoor ();
			resetCheckValues ();
			camToggled = false;
			puzzleFinished = false;

			//lower additive
			GlobalController.Instance.decAdditive();
		}



	}

	public void resetCheckValues(){
		foreach (GameObject slot in checkSlots) {
			slot.GetComponent<ArrayReaction>().resetSuccessBool ();
		}
	}

	public void openDoor(){
		door.SetActive (false);
	}
	public void closeDoor(){
		door.SetActive (true);
	}
	//reset slots to empty
	public void resetSlots(){
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		foreach (GameObject repTile in replacementTiles) {
			Destroy (repTile);
		}
	}

	// reset tiles to active and in original position
	public void resetTiles(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			//arrayTiles [i].gameObject.SetActive (false);
			arrayTiles[i].GetComponent<TileDrag>().onReset();
		}


	}

	public void resetActive()
	{
		for (int i = 0; i < arrayTiles.Length; i++) 
		{
			arrayTiles[i].gameObject.SetActive(true);
		}
	}

	public bool checkInputSuccess(){
		foreach (GameObject slot in checkSlots) {
			if (!slot.GetComponent<ArrayReaction>().success) {
				return false;
			}
		}
		return true;
	}

	public bool checkInputName(){
		if (checkSlots [0].GetComponent<ArrayReaction>().giveName == "ReplacementMOD" &&
			checkSlots [1].GetComponent<ArrayReaction>().giveName == "Replacement-" &&
			checkSlots [2].GetComponent<ArrayReaction>().giveName == "ReplacementParenO" &&
			checkSlots [3].GetComponent<ArrayReaction>().giveName == "Replacement-" &&
			checkSlots [4].GetComponent<ArrayReaction>().giveName == "ReplacementParenC") 
		{
			return true;
		}
		return false;
	}


}
