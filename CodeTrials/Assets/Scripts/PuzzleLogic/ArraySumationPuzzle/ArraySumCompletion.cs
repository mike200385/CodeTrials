using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ArraySumCompletion : MonoBehaviour {

	// LEVEL MANAGER FOR THE ARRAY LEVEL

	public ArrayReaction checkOne, checkTwo, checkThree;
	public GameObject risingPlatform; // rising counter-weight platform
	public GameObject[] arrayTiles; // the tiles that will be dragged
	public GameObject[] replacementTiles;
	public List<Vector3> arrayTilePositions; // their positions, used for resetting challenge

	public bool puzzleFinished, camToggled;
	// Use this for initialization
	void Start () {
		risingPlatform = GameObject.FindGameObjectWithTag ("RisingPlatform");
		arrayTiles = GameObject.FindGameObjectsWithTag ("ArrayTile");
		puzzleFinished = false;
		camToggled = false;
		arrayTilePositions = new List<Vector3> ();
		//store initial tile position in order to place them back there
		foreach(GameObject tile in arrayTiles) {
			arrayTilePositions.Add (tile.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if all 3 spots are filled
		if (checkOne.success && checkTwo.success && checkThree.success) {
			//drop the platforms
			if (!camToggled) {
				GlobalController.Instance.toggleCamera ();
				camToggled = true;
			}
			//NOTE score is added in Rising Platform Script

			dropTilePlatforms ();
			puzzleFinished = true;
		}	

		//reset puzzle and boxes
		if (puzzleFinished && Input.GetKeyDown(KeyCode.R)) {
			//GlobalController.Instance.resetBoxBools();
			resetTiles ();
			resetSlots ();
			resetActive ();
			resetBoxesAndPlatforms ();
			resetCheckValues ();
			camToggled = false;
			puzzleFinished = false;

			//lower additive
			GlobalController.Instance.decAdditive();
		}

	}

	public void resetCheckValues(){
		checkOne.resetSuccessBool ();
		checkTwo.resetSuccessBool ();
		checkThree.resetSuccessBool ();
	}

	public void dropTilePlatforms(){
		foreach (GameObject temp in arrayTiles) {
			// if this tile was used as part of the sum
			if (temp.GetComponent<ArrayTileController> ().isUsed) { 
				//drop it's corresponding box
				temp.GetComponent<ArrayTileController> ().connectedBox.dropPlatform();

			}
				
		}
		//resetCheckValues ();
	}
	//reset slots to empty
	public void resetSlots(){
		replacementTiles = GameObject.FindGameObjectsWithTag ("ReplaceTile");

		foreach (GameObject repTile in replacementTiles) {
			Destroy (repTile);
		}
		//THIS LINE ALSO CAUSES PROBLEMS
		resetCheckValues ();
	}

	// reset tiles to active and in original position
	public void resetTiles(){
		for (int i = 0; i < arrayTiles.Length; i++) {
			arrayTiles [i].transform.position = arrayTilePositions [i]; // move to original position
			arrayTiles [i].GetComponent<ArrayTileController> ().resetUsed (); // change bool to false;
			// THIS LINE MESSES UP THE RESET
			arrayTiles [i].gameObject.SetActive (true);

		}
	}


	public void resetActive()
	{
		for (int i = 0; i < arrayTiles.Length; i++) 
		{
			arrayTiles[i].gameObject.SetActive(true);
		}
	}

	public void resetBoxesAndPlatforms(){
		//set all boxes to their spot back in the air
		foreach (GameObject temp in arrayTiles) {
			if (temp.GetComponent<ArrayTileController> ().connectedBox != null) {
				temp.GetComponent<ArrayTileController> ().connectedBox.resetBox ();	
			}
		}
		risingPlatform.GetComponent<RisingPlatformController> ().resetPlatformTotally ();

	}



}
