using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzleCompletionCheck : MonoBehaviour {

	// LEVEL MANAGER FOR THE ARRAY LEVEL

	public GameObject[] checkSlots; //manually set in inspector
	public GameObject[] barriers;//manually set in inspector
	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles;

	public bool puzzleFinished, camToggled, scoreChanged;
	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
	}

	// Update is called once per frame
	void Update () {
		//if all 5 spots are filled
		if (checkInputSuccess () && checkInputName ()) {
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
				//raise the barriers
				openBarriers();
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
			resetBarriers();
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

	public void openBarriers(){
		//open the first barrier
		//barriers [0].GetComponent<BarrierController> ().moveBarrier ();
//		foreach (GameObject barr in barriers) {
//			barr.GetComponent<BarrierController> ().moveBarrier ();
//		}
		GameObject temp = GameObject.FindGameObjectWithTag ("RisingPlatform");
		temp.GetComponent<MovingObject> ().enabled = true;
	}
	public void resetBarriers(){
		//place back in original pos
		foreach (GameObject barr in barriers) {
			barr.GetComponent<BarrierController> ().resetPosition ();
			barr.GetComponent<BarrierController> ().triggerCollider.gameObject.SetActive (true);
		}
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
		if (checkSlots [0].GetComponent<ArrayReaction>().giveName == "Replacement-" &&
			checkSlots [1].GetComponent<ArrayReaction>().giveName == "Replacement-" &&
			checkSlots [2].GetComponent<ArrayReaction>().giveName == "ReplacementX" &&
			checkSlots [3].GetComponent<ArrayReaction>().giveName == "ReplacementMOD" &&
			checkSlots [4].GetComponent<ArrayReaction>().giveName == "ReplacementX") 
		{
			return true;
		}
		return false;
	}


}


