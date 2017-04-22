using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompletionCheck2 : MonoBehaviour {
	
	public ArrayReaction threeSuccess, fiveSuccess, plusSuccess, plusPlusSuccess;
	public ArrayReaction replacementThree, replacementFive, replacementPlus, replacementPlusPlus;

	public bool puzzleFinished, camToggled, doorOpened, scoreChanged;

	public GameObject doorTwo;
	private Vector3 doorTwoStartingPosition, doorTwoOpenPosition;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots

	public AudioSource solved, raiseDoor;


	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		doorOpened = false;
		scoreChanged = false;
		doorTwoStartingPosition = doorTwo.transform.position; //The starting position of the door in the scene
		doorTwoOpenPosition = new Vector3 (doorTwo.transform.position.x, doorTwo.transform.position.y + 100.0f, 
			doorTwo.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {

		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		if (threeSuccess.success && replacementThree.giveName == "Replacement3" &&
			plusSuccess.success && replacementPlus.giveName == "Replacement+" &&
			plusPlusSuccess.success && replacementPlusPlus.giveName == "Replacement+" &&
			fiveSuccess.success && replacementFive.giveName == "Replacement5"){
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
			}
			if (!doorOpened) {
				openDoor ();
			}
			puzzleFinished = true;
			GlobalController.Instance.nestedForLoopComplete = true;
			if (!scoreChanged) {
				GlobalController.Instance.incScore ();
				solved.Play ();
				scoreChanged = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.R) && GlobalController.Instance.camName == "NestedForLoopCamera"){
			closeDoor ();
			doorOpened = false;
			GlobalController.Instance.nestedForLoopComplete = false;
			resetTiles ();
			resetSlots ();
			resetActive ();
			resetCheckValues ();
			camToggled = false;
			puzzleFinished = false;
			//Lower Score
			GlobalController.Instance.decAdditive ();
		}
	}

	public void resetCheckValues(){
		threeSuccess.resetSuccessBool ();
		fiveSuccess.resetSuccessBool ();
		plusSuccess.resetSuccessBool ();
		plusPlusSuccess.resetSuccessBool ();
	}

	void openDoor(){
		doorTwo.transform.position = doorTwoOpenPosition;
		doorOpened = true;
		raiseDoor.Play ();
		raiseDoor.loop = false;
	}

	void closeDoor(){
		doorTwo.transform.position = doorTwoStartingPosition;
		raiseDoor.Play ();
		raiseDoor.loop = false;
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