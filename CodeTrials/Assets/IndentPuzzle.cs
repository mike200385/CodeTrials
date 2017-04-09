using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndentPuzzle : MonoBehaviour {

	float indentIncrement = 100.0f;
	//Line One of Code
	public GameObject textLineOne;
	public GameObject textLineTwo;
	public GameObject textLineThree;
	public GameObject textLineFour;
	public GameObject textLineFive;

	//Log the starting position of code text objects
	private Vector3 textLineOneStart;
	private Vector3 textLineTwoStart;
	private Vector3 textLineThreeStart;
	private Vector3 textLineFourStart;
	private Vector3 textLineFiveStart;

	//increment to check for completions
	public int indentCounterOne = 0;
	public int indentCounterTwo = 0;
	public int indentCounterThree = 0;
	public int indentCounterFour = 0;
	public int indentCounterFive = 0;

	// Use this for initialization
	void Start () {
		textLineOneStart = textLineOne.transform.position;
		textLineTwoStart = textLineTwo.transform.position;
		textLineThreeStart = textLineThree.transform.position;
		textLineFourStart = textLineFour.transform.position;
		textLineFiveStart = textLineFive.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}

	//FIRST BUTTON
	public void indentButtonOne(){
		//when clicked move the text object line by offset pixels to the right. With a limit to the screen.
		//need to access the text gameobject.
		if (indentCounterOne < 5 && indentCounterOne >= 0) {
			textLineOne.transform.position = new Vector3 (textLineOne.transform.position.x + indentIncrement,
				textLineOne.transform.position.y, 0); 
			indentCounterOne++;
		}
	}

	public void unindentButtonOne(){
		if (indentCounterOne <= 5 && indentCounterOne > 0) {
			textLineOne.transform.position = new Vector3 (textLineOne.transform.position.x - indentIncrement,
				textLineOne.transform.position.y, 0); 
			indentCounterOne--;
		}
	}

	//SECOND BUTTON
	public void indentButtonTwo(){
		//when clicked move the text object line by offset pixels to the right. With a limit to the screen.
		//need to access the text gameobject.
		if (indentCounterTwo < 5 && indentCounterTwo >= 0) {
			textLineTwo.transform.position = new Vector3 (textLineTwo.transform.position.x + indentIncrement,
				textLineTwo.transform.position.y, 0); 
			indentCounterTwo++;
		}
	}

	public void unindentButtonTwo(){
		if (indentCounterTwo <= 5 && indentCounterTwo > 0) {
			textLineTwo.transform.position = new Vector3 (textLineTwo.transform.position.x - indentIncrement,
				textLineTwo.transform.position.y, 0); 
			indentCounterTwo--;
		}
	}
	//THIRD BUTTON
	public void indentButtonThree(){
		//when clicked move the text object line by offset pixels to the right. With a limit to the screen.
		//need to access the text gameobject.
		if (indentCounterThree < 5 && indentCounterThree >= 0) {
			textLineThree.transform.position = new Vector3 (textLineThree.transform.position.x + indentIncrement,
				textLineThree.transform.position.y, 0); 
			indentCounterThree++;
		}
	}
		
	public void unindentButtonThree(){
		if (indentCounterThree <= 5 && indentCounterThree > 0) {
			textLineThree.transform.position = new Vector3 (textLineThree.transform.position.x - indentIncrement,
				textLineThree.transform.position.y, 0); 
			indentCounterThree--;
		}
	}

	//FOURTH BUTTON
	public void indentButtonFour(){
		//when clicked move the text object line by offset pixels to the right. With a limit to the screen.
		//need to access the text gameobject.
		if (indentCounterFour < 5 && indentCounterFour >= 0) {
			textLineFour.transform.position = new Vector3 (textLineFour.transform.position.x + indentIncrement,
				textLineFour.transform.position.y, 0); 
			indentCounterFour++;
		}
	}

	public void unindentButtonFour(){
		if (indentCounterFour <= 5 && indentCounterFour > 0) {
			textLineFour.transform.position = new Vector3 (textLineFour.transform.position.x - indentIncrement,
				textLineFour.transform.position.y, 0); 
			indentCounterFour--;
		}
	}

	//FIFTH BUTTON
	public void indentButtonFive(){
		//when clicked move the text object line by offset pixels to the right. With a limit to the screen.
		//need to access the text gameobject.
		if (indentCounterFive < 5 && indentCounterFive >= 0) {
			textLineFive.transform.position = new Vector3 (textLineFive.transform.position.x + indentIncrement,
				textLineFive.transform.position.y, 0); 
			indentCounterFive++;
		}
	}

	public void unindentButtonFive(){
		if (indentCounterFive <= 5 && indentCounterFive > 0) {
			textLineFive.transform.position = new Vector3 (textLineFive.transform.position.x - indentIncrement,
				textLineFive.transform.position.y, 0); 
			indentCounterFive--;
		}
	}

	public void resetLines(){
		//Return all lines to original positions
		textLineOne.transform.position = textLineOneStart;
		textLineTwo.transform.position = textLineTwoStart;
		textLineThree.transform.position = textLineThreeStart;
		textLineFour.transform.position = textLineFourStart;
		textLineFive.transform.position = textLineFiveStart;

		//Return all iterators to 0
		indentCounterOne = 0;
		indentCounterTwo = 0;
		indentCounterThree = 0;
		indentCounterFour = 0;
		indentCounterFive = 0;

	}
}
