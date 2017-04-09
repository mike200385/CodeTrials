using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompletionScriptThree : MonoBehaviour {

	public ArrayReaction oneSuccess, twoSuccess, threeSuccess, fourSuccess, fiveSuccess,
						 doorNumberSuccess;
	public ArrayReaction replacementOne, replacementTwo, replacementThree, replacementFour, replacementFive,
						 replacementDoorNumber;

	public bool puzzleFinished, camToggled, scoreChanged;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots
	public GameObject arithmeticPortal, conditionalPortal, arrayPortal, loopPortal, finalPortal;//The Portals
	public GameObject arithLevTag, condLevTag, arrayLevTag, loopLevTag;


	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		scoreChanged = false;
		arithmeticPortal.SetActive (false);
		conditionalPortal.SetActive (false);
		loopPortal.SetActive (false);
		arrayPortal.SetActive (false);
		finalPortal.SetActive (false);
		arithLevTag.SetActive (false);
		condLevTag.SetActive (false);
		arrayLevTag.SetActive (false);
		loopLevTag.SetActive (false);
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
		}

		//Open Portal to Conditionals
		if(twoSuccess.success && twoSuccess.giveName == "Replacement2" &&
			doorNumberSuccess.success && doorNumberSuccess.giveName == "ReplacementdoorNumber" &&
			!puzzleFinished){
				//Instantiate the Conditional Ops portal
				conditionalPortal.SetActive (true);
				condLevTag.SetActive (true);
				puzzleFinished = true;
		}

		//Open Portal to Array
		if(threeSuccess.success && threeSuccess.giveName == "Replacement3" &&
			doorNumberSuccess.success && doorNumberSuccess.giveName == "ReplacementdoorNumber" &&
			!puzzleFinished){
				//instantiate the array portal
				arrayPortal.SetActive (true);
				arrayLevTag.SetActive (true);
				puzzleFinished = true;
		}

		//Open Portal to Loop
		if(fourSuccess.success && fourSuccess.giveName == "Replacement4" &&
			doorNumberSuccess.success && doorNumberSuccess.giveName == "ReplacementdoorNumber" &&
			!puzzleFinished){
				//instantiate the loop portal
				loopPortal.SetActive (true);
				loopLevTag.SetActive (true);
				puzzleFinished = true;
		}

		//Open Portal to Final
		if(fiveSuccess.success && fiveSuccess.giveName == "Replacement5" &&
			doorNumberSuccess.success && doorNumberSuccess.giveName == "ReplacementdoorNumber" &&
			!puzzleFinished){
				//instantiate the final portal
				finalPortal.SetActive (true);
				puzzleFinished = true;
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
			conditionalPortal.SetActive (false);
			loopPortal.SetActive (false);
			arrayPortal.SetActive (false);
			finalPortal.SetActive (false);
			arithLevTag.SetActive (false);
			condLevTag.SetActive (false);
			arrayLevTag.SetActive (false);
			loopLevTag.SetActive (false);
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
