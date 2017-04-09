using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SingleForJIT : MonoBehaviour {
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
		

	public void showTextTwo(){
		help.text = "Did you notice that there was a door in the room we are in? \n" +
			"and it had a number on it, we want to make sure the correct value \n" +
			"of 'i' is passed to the door.";
	}

	public void showTextThree(){
		help.text = "The process is this - i has the value of 0 before we begin, we start \nthe for loop. " +
			"Then we ask 'Is the value of i (as of now it is 0) the \nsame value for the number on the door? " +
			"No? The value of the door is\n'2' and the value of 'i' right now is 0, therefore " +
			"we don't enter \nthe 'if' condition ending the first pass through of the loop.";
	}

	public void showTextFour(){
		help.text = "Now our 'i' at the end of the last loop was 0, and we want \n" +
		"increase it by 1 or decrease it by 1, the proper syntax to increment \n" +
		"something by 1, is '+ +' which is a shorthand way of saying i = i + 1.\n" +
		"and to decrease by 1, we would use '- -'.";
	}

	public void showTextFive(){
		help.text = "Here we want the value to increase " +
		"by 1 each time through the loop\nuntil it reaches the end condition of the for loop, " +
		"which is\nconvenient, because that is also the value we need to open the door!";
	}

	void removeText(){
		help.text = "";
	}
}