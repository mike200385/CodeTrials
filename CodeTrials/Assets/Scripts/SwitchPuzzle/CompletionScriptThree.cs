using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompletionScriptThree : MonoBehaviour {

	public ArrayReaction oneSuccess, doorNumberSuccess;
	public ArrayReaction replacementOne, replacementDoorNumber;

	public bool puzzleFinished, camToggled, scoreChanged, doorOpened;

	private Vector3 doorOneStartingPosition, doorOneOpenPosition;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots
	public GameObject arithmeticPortal, doorOne;
	public GameObject arithLevTag, condLevTag, arrayLevTag, loopLevTag;


	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		arithmeticPortal.SetActive (false);
		arithLevTag.SetActive (false);
		doorOneStartingPosition = doorOne.transform.position; //The starting position of the door in the scene
		doorOneOpenPosition = new Vector3 (doorOne.transform.position.x, doorOne.transform.position.y + 10.0f, 
			doorOne.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		//Open Portal to Arithmetic Ops
		if(oneSuccess.success && oneSuccess.giveName == "Replacement1" &&
			doorNumberSuccess.success && doorNumberSuccess.giveName == "ReplacementdoorNumber" &&
			!puzzleFinished){
				//instantiate the arimetic portal.
				openDoor();
				arithmeticPortal.SetActive(true);
				arithLevTag.SetActive (true);
				if (!camToggled) {
					GlobalController.Instance.toggleCamera ();
					camToggled = true;
				}
				puzzleFinished = true;
		}
			

		//The Reset Logic
		if (Input.GetKeyDown (KeyCode.R) && GlobalController.Instance.camName == "SwitchCamera") {
			resetTiles ();
			resetSlots ();
			resetActive ();
			resetCheckValues ();
			closeDoor ();
			camToggled = false;
			puzzleFinished = false;
			arithmeticPortal.SetActive (false);
			arithLevTag.SetActive (false);
		}
			
	}



	void openDoor(){
		doorOne.transform.position = doorOneOpenPosition;
		doorOpened = true;
	}

	void closeDoor(){
		doorOne.transform.position = doorOneStartingPosition;
		doorOpened = false;
	}
		

	public void resetCheckValues(){
		oneSuccess.resetSuccessBool ();
		doorNumberSuccess.resetSuccessBool ();
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
			arrayTiles [i].gameObject.SetActive (true);
		}
	}

}
