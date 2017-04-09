using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WhileJIT : MonoBehaviour {
	public Text help;
	public bool down = false;

	void Awake(){
		help.text = "";
	}

	void Update(){
		if (Input.GetKeyDown ("d")) {
			removeText ();
		}
	}


	public void showTextOne(){
		help.text = "While loops seem simple to understand, it is a condition which says \n" +
		"while 'a something' is true, keep doing whatever I am told.";	
	}

	public void showTextTwo(){
		help.text = "But, it is important to remember that there needs to be something \n" +
		"that allows you to exit the while loop. Otherwise laserbeams will continue to \n" +
		"keep powering this force-field and you can't get that key!";
	}

	public void showTextThree(){
		help.text = "In our case, the variable 'x' is always smaller than 6, because \n" +
			"it currently equals 2. And there is no way to make x greater than 6 until you \n" +
			"add in the code. ";
	}

	public void showTextFour(){
		help.text = "Here we can use the iterator '++' to increase the value of 'x' every \n" +
			"time we go through the while loop. After a few runs, these lasers will disappear. ";
	}




	void removeText(){
		help.text = "";
	}
}