using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CompletionScriptFour : MonoBehaviour{

	public ArrayReaction xSuccess, plusSuccess, plusPlusSuccess;
	public ArrayReaction replacementX;
	public ArrayReaction replacementPlus;
	public ArrayReaction replacementPlusPlus;

	public bool puzzleFinished, camToggled, laserOff, scoreChanged;

	public GameObject laser;
	private Vector3 laserStartingPosition, laserRemovedPosition;

	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles; //The replacements when tiles dragged into the slots

	// Use this for initialization
	void Start () {
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		laserOff = false;
		scoreChanged = false;
		laserStartingPosition = laser.transform.position; //The starting position of the door in the scene
		laserRemovedPosition = new Vector3 (laser.transform.position.x, laser.transform.position.y + 50.0f, 
			laser.transform.position.z);

	}

	// Update is called once per frame
	void Update () {

		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		if (xSuccess.success && replacementX.giveName == "ReplacementX" &&
			plusSuccess.success && replacementPlus.giveName == "Replacement+" &&
			plusPlusSuccess.success && replacementPlusPlus.giveName == "Replacement+"){
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
			}
			if (!laserOff) {
				removeLaser ();
			}
			puzzleFinished = true;
			GlobalController.Instance.whileLoopComplete = true;
			if (!scoreChanged) {
				GlobalController.Instance.incScore ();
				scoreChanged = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.R) && GlobalController.Instance.camName == "WhileLoopPuzzleCamera"){
			replaceLaser ();
			laserOff = false;
			GlobalController.Instance.whileLoopComplete = false;
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
		xSuccess.resetSuccessBool ();
		plusSuccess.resetSuccessBool ();
		plusPlusSuccess.resetSuccessBool ();
	}

	void removeLaser(){
		laser.transform.position = laserRemovedPosition;
		laserOff = true;
	}

	void replaceLaser(){
		laser.transform.position = laserStartingPosition;
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
