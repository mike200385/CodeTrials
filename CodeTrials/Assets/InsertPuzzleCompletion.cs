using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertPuzzleCompletion : MonoBehaviour {

	public IndentPuzzle lineOne;
	public IndentPuzzle lineTwo;
	public IndentPuzzle lineThree;
	public IndentPuzzle lineFour;
	public IndentPuzzle lineFive;

	public GameObject doorOne;
	private Vector3 doorOneStartingPosition, doorOneOpenPosition;

	public bool puzzleFinished, camToggled, doorOpened, scoreChanged;

	// Use this for initialization
	void Start () {
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
		doorOneStartingPosition = doorOne.transform.position; //The starting position of the door in the scene
		doorOneOpenPosition = new Vector3 (doorOne.transform.position.x - 10.0f, doorOne.transform.position.y, 
			doorOne.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (lineOne.indentCounterOne == 0 && lineTwo.indentCounterTwo == 1 &&
		   lineThree.indentCounterThree == 2 && lineFour.indentCounterFour == 1 &&
		   lineFive.indentCounterFive == 0) {

			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
			}
			if (!doorOpened) {
				openDoor ();
			}
			puzzleFinished = true;
			GlobalController.Instance.indentComplete = true;
			if (!scoreChanged) {
				GlobalController.Instance.incScore ();
				scoreChanged = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.R) && GlobalController.Instance.camName == "IndentCamera") {
			closeDoor ();
			doorOpened = false;
			puzzleFinished = false;
			GlobalController.Instance.indentComplete = false;
			lineOne.resetLines ();
			lineTwo.resetLines ();
			lineThree.resetLines ();
			lineFour.resetLines ();
			lineFive.resetLines ();
			//Lower Score
			GlobalController.Instance.decAdditive ();

		}
		
	}

	public void openDoor(){
		doorOne.transform.position = doorOneOpenPosition;
		doorOpened = true;
	}

	public void closeDoor(){
		doorOne.transform.position = doorOneStartingPosition;
	}
}
