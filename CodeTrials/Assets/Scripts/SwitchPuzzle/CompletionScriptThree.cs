using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompletionScriptThree : MonoBehaviour {

	public ArrayReaction oneSuccess, twoSuccess, threeSuccess, fourSuccess, fiveSuccess,
						 doorNumberSuccess;
	public ArrayReaction replacementOne, replacementTwo, replacementThree, replacementFour, replacementFive,
						 replacementDoorNumber;

	public bool puzzleFinished, camToggled, scoreChanged;
	public AudioSource solved, raiseDoor;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots
	public GameObject arithmeticPortal;
	public GameObject arithLevTag;


	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
		arithmeticPortal.SetActive (false);
		arithLevTag.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		//Open Portal to Arithmetic Ops
		if(oneSuccess.success && oneSuccess.giveName == "Replacement1" &&
			doorNumberSuccess.success && doorNumberSuccess.giveName == "ReplacementdoorNumber" &&
			!puzzleFinished){
				//instantiate the arimetic portal.
				arithmeticPortal.SetActive(true);
				arithLevTag.SetActive (true);
				puzzleFinished = true;
				if (!camToggled) {
					GlobalController.Instance.toggleCamera ();
					camToggled = true;
					solved.Play ();
				}
		}
	

		//The Reset Logic
		if (Input.GetKeyDown (KeyCode.R) && GlobalController.Instance.camName == "SwitchCamera") {
			resetTiles ();
			resetSlots ();
			resetActive ();
			resetCheckValues ();
			camToggled = false;
			puzzleFinished = false;
			arithmeticPortal.SetActive (false);
			arithLevTag.SetActive (false);
		}
			
	}
		

	public void resetCheckValues(){
		oneSuccess.resetSuccessBool ();
		twoSuccess.resetSuccessBool ();
		threeSuccess.resetSuccessBool ();
		fourSuccess.resetSuccessBool ();
		fiveSuccess.resetSuccessBool ();
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
