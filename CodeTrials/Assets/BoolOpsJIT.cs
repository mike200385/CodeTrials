using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoolOpsJIT : MonoBehaviour {
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
		help.text = "A for loop has 3 properites. The beginning value of an item \n" +
			"an ending point of the item, and the iterator which you can tell the \n" +
			"item how much to increase or decrease after each iteration. Here, \n" +
			"the value of 'i' is 0 at the beginning, can go all the way to 2, \n" +
			"and it needs to be incremented to get there."; 
	}

	void removeText(){
		help.text = "";
	}
		
}
