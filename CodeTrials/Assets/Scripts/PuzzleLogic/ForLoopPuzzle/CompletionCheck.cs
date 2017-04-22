using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompletionCheck : MonoBehaviour {

	public ArrayReaction twoSuccess, plusSuccess, plusPlusSuccess;
	public ArrayReaction replacementTwo;
	public ArrayReaction replacementPlus;
	public ArrayReaction replacementPlusPlus;

	public AudioSource solved, raiseDoor;

	public bool puzzleFinished, camToggled, doorOpened, scoreChanged;

	public GameObject doorOne;
	private Vector3 doorOneStartingPosition, doorOneOpenPosition;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots

	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		doorOpened = false;
		scoreChanged = false;
		doorOneStartingPosition = doorOne.transform.position; //The starting position of the door in the scene
		doorOneOpenPosition = new Vector3 (doorOne.transform.position.x, doorOne.transform.position.y + 5.0f, 
			doorOne.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {

		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		if (twoSuccess.success && replacementTwo.giveName == "Replacement2" &&
			plusSuccess.success && replacementPlus.giveName == "Replacement+" &&
			plusPlusSuccess.success && replacementPlusPlus.giveName == "Replacement+"){
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
			}
			if (!doorOpened) {
				openDoor ();
			}
			puzzleFinished = true;
			GlobalController.Instance.singleForLoopComplete = true;
			if (!scoreChanged) {
				GlobalController.Instance.incScore ();
				solved.Play ();
				scoreChanged = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.R) && GlobalController.Instance.camName == "SingleLoopCamera"){
			closeDoor ();
			doorOpened = false;
			GlobalController.Instance.singleForLoopComplete = false;
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
		twoSuccess.resetSuccessBool ();
		plusSuccess.resetSuccessBool ();
		plusPlusSuccess.resetSuccessBool ();
	}

	void openDoor(){
		doorOne.transform.position = doorOneOpenPosition;
		doorOpened = true;
		raiseDoor.Play ();
	}

	void closeDoor(){
		doorOne.transform.position = doorOneStartingPosition;
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



