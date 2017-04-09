using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NestedForJIT : MonoBehaviour {
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
		help.text = "Much like before when we came across the for loop, here we have a nested \n" +
		"for loop. These can be tricky, but it is important to step through them \nslowly." +
		"So, the outer loop (with 'x' as the variable we are incrementing) \nwill run 1 time, " +
		"then, the inner loop(the variable 'y') will run 5 times!";
	}

	public void showTextTwo(){
		help.text = "Nested loops are really good for things like coordinate systems, because \n" +
		"they can cycle through all the different ordered pairs pretty quickly. \n" +
		"Here in this puzzle we have a grid set up. We want to go an 'x' number of \n" +
		"spaces on the x-axis and a 'y' number of spaces up the y-axis.";
	}

	public void showTextThree(){
		help.text = "So, if everytime the outer loop runs 1 time, the inner loop runs 5 times. \n" +
		"the outer loop is our x-coordinate, and the inner is y. The first trip  \nthrough the loop" +
			" it will be like (1,1), (1,2), ... , (1,5). \nThen (2,1), ... ,(2,5). We want the " +
		"loops to stop when they hit the \ncoordinate we want. ";
	}

	public void showTextFour(){
		help.text = "Remember, the ! symbol in C++ is a NOT statement, so our desired\n" +
		"coordinates are (3,5) and we want to pass the console our X and Y \ncoordinates.";
	}




	void removeText(){
		help.text = "";
	}
}