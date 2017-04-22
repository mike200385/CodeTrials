using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //allows us to get name of buttons that are clicked

public class HelpButtons : MonoBehaviour {

	public Text helpText;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showHelpText(){
		switch (this.gameObject.name) {

		//DATATYPE BUTTONS
		case "HelpButton1_Dt":
			helpText.text =
			"Remember that each variable needs a datatype. \nIt could be a long, int, bool, float, string, char, double, and more";
			break;
		case "HelpButton2_Dt":
			helpText.text = "Here's a hint: Doubles carry values like 33.9. Also bools can only hold 1 of 2 values.";
			break;
		//ARITHMETIC BUTTONS
		case "HelpButton1_Arth":
			helpText.text = "Remember PEMDAS! That will help you order your parentheses and operations.";
			break;
		case "HelpButton2_Arth":
			helpText.text = "Try out some combinations and see if they equal 30, there's only 1 correct answer.";
			break;
		case "HelpButton3_Arth":
			helpText.text =
				"Here's a hint: You'll probably need to divide.";
			break;
		//ARRAY ACCESS BUTTONS
		case "HelpButton1_Acc":
			helpText.text = "Arrays must be accessed with correct indexes to avoid errors.\n" +
			"Remember that arrays begin counting at 0!";
			break;
		case "HelpButton2_Acc":
			helpText.text = "You want the first, third, and last platforms to be activated.\n" +
			"Here's a hint: the third element of an array is the 2nd element.";
			break;
		case "HelpButton3_Acc":
			helpText.text =
				"N or N-1? Is there a difference if we start counting at 0? There definitely is.";
			break;
		//ARRAY BOX SUM BUTTONS
		case "HelpButton1_Arr":
			helpText.text =
				"The required weight is 14, so you need to pick the correct elements to meet that total.\n" +
			"There are multiple ways to complete this task.";
			break;
		case "HelpButton2_Arr":
			helpText.text = "Remember that array indexes begin at 0!\n" +
			"This will help you to make sure that you choose the correct elements";
			break;

		//CONDITIONAL BOOLOPS BUTTONS
		case "HelpButton1_BOOL":
			helpText.text = "The conditions for bool can be expressed as true or false. \n" +
			"The indication is that the '!' sign acts a negation.";
			break;
		case "HelpButton2_BOOL":
			helpText.text = "Instead of saying if(x == true), the better way to say it is simply \n" +
			"'if(x), and instead of if(x != true), we could say that if(!x).";
			break;
		
		//CONDITIONAL LOGOR BUTTONS
		case "HelpButton1_OR":
			helpText.text = "Logical And (&&) and Logical Or (||) are important concepts to programming. \n" +
			"&& means that the two compared conditions must share the same value, such as: if(x && y) \n" +
			"where x and y are both boolean expressions that evaluate to true, then the procedures\n" +
			"within if(x && y) would run.";
			break;

		case "HelpButton2_OR":
			helpText.text = "Conversely, Logical Or (||) implies that either one or the other must be true \n" +
			"to enter the if statement. For example, if(x || y), where x is true and y is false, would  \n" +
			"also enter the if(x || y) statement. ";
			break;

		//CONDITIONAL LOGAND BUTTONS
		case "HelpButton1_AND":
			helpText.text = "Logical And (&&) and Logical Or (||) are important concepts to programming. \n" +
			"&& means that the two compared conditions must share the same value, such as: if(x && y) \n" +
			"where x and y are both boolean expressions that evaluate to true, then the procedures\n" +
			"within if(x && y) would run.";
			break;

		case "HelpButton2_AND":
			helpText.text = "Conversely, Logical Or (||) implies that either one or the other must be true \n" +
			"to enter the if statement. For example, if(x || y), where x is true and y is false, would  \n" +
			"also enter the if(x || y) statement. ";
			break;

		//LOOP SINGLE FOR BUTTONS
		case "HelpButton1_SINGLEFOR":
			helpText.text = "A for loop has 3 properites. The beginning value of an item \n" +
			"an ending point of the item, and the iterator which you can tell the \n" +
			"item how much to increase or decrease after each iteration. Here, \n" +
			"the value of 'i' is 0 at the beginning, can go all the way to 2, \n" +
			"and it needs to be incremented to get there.";
			break;
		
		case "HelpButton2_SINGLEFOR":
			helpText.text = "Did you notice that there was a door in the room we are in? \n" +
			"and it had a number on it, we want to make sure the correct value \n" +
			"of 'i' is passed to the door.";
			break;

		case "HelpButton3_SINGLEFOR":
			helpText.text = "The process is this - i has the value of 0 before we begin, we start \nthe for loop. " +
			"Then we ask 'Is the value of i (as of now it is 0) the \nsame value for the number on the door? " +
			"No? The value of the door is\n'2' and the value of 'i' right now is 0, therefore " +
			"we don't enter \nthe 'if' condition ending the first pass through of the loop.";
			break;

		case "HelpButton4_SINGLEFOR":
			helpText.text = "Now our 'i' at the end of the last loop was 0, and we want \n" +
			"increase it by 1 or decrease it by 1, the proper syntax to increment \n" +
			"something by 1, is '+ +' which is a shorthand way of saying i = i + 1.\n" +
			"and to decrease by 1, we would use '- -'.";
			break;

		//LOOP NESTED FOR BUTTONS

		case "HelpButton1_NESTEDFOR":
			helpText.text = "Much like before when we came across the for loop, here we have a nested \n" +
			"for loop. These can be tricky, but it is important to step through them \nslowly." +
			"So, the outer loop (with 'x' as the variable we are incrementing) \nwill run 1 time, " +
			"then, the inner loop(the variable 'y') will run 5 times!";
			break;

		case "HelpButton2_NESTEDFOR":
			helpText.text = "Nested loops are really good for things like coordinate systems, because \n" +
			"they can cycle through all the different ordered pairs pretty quickly. \n" +
			"Here in this puzzle we have a grid set up. We want to go an 'x' number of \n" +
			"spaces on the x-axis and a 'y' number of spaces up the y-axis.";
			break;

		case "HelpButton3_NESTEDFOR":
			helpText.text = "So, if everytime the outer loop runs 1 time, the inner loop runs 5 times. \n" +
			"the outer loop is our x-coordinate, and the inner is y. The first trip  \nthrough the loop" +
			" it will be like (1,1), (1,2), ... , (1,5). \nThen (2,1), ... ,(2,5). We want the " +
			"loops to stop when they hit the \ncoordinate we want. ";
			break;

		case "HelpButton4_NESTEDFOR":
			helpText.text = "Remember, the ! symbol in C++ is a NOT statement, so our desired\n" +
			"coordinates are (3,5) and we want to pass the console our X and Y \ncoordinates.";
			break;

		//LOOP WHILE BUTTONS
		case "HelpButton1_WHILE":
			helpText.text = "While loops seem simple to understand, it is a condition which says \n" +
			"while 'a something' is true, keep doing whatever I am told.";
			break;

		case "HelpButton2_WHILE":
			helpText.text = "But, it is important to remember that there needs to be something \n" +
				"that allows you to exit the while loop. Otherwise laserbeams will continue to \n" +
				"keep powering this force-field and you can't get that key!";
			break;

		case "HelpButton3_WHILE":
			helpText.text = "In our case, the variable 'x' is always smaller than 6, because \n" +
				"it currently equals 2. And there is no way to make x greater than 6 until you \n" +
				"add in the code. ";
			break;

		case "HelpButton4_WHILE":
			helpText.text = "Here we can use the iterator '++' to increase the value of 'x' every \n" +
				"time we go through the while loop. After a few runs, these lasers will disappear. ";
			break;
		
		//Indentation Puzzle

		case "HelpButton1_INDENT":
			helpText.text = "Use the left and right facing arrows to increase or decrease the indentation.";
			break;

		case "HelpButton2_INDENT":
			helpText.text = "The closing bracket for the if statement, must be aligned with the first letter of \n" +
				"the 'i' in the if statement";
			break;
	

		case "HelpButton3_INDENT":
			helpText.text = "The inner closing bracket belongs to the for loop and must be aligned to the 'f' \n" +
				"in the 'for' statement.";
			break;

		//SWITCH PUZZLE
		case "HelpButton1_SWITCH":
			helpText.text = "The switch statement is a series\n" +
				"of conditions that can be\n" +
				"selected by their case number.\n" +
				"In this puzzle, drag the desired tile\n" +
				"number and assign\n" +
				"to door number";
			break;
		case "HelpButton2_SWITCH":
			helpText.text = "A switch statement needs\n" +
				"a condition to switch on,\n" +
				"that condition here is\n" +
				"doorNumber";
			break;

		}
	}

	void OnMouseEnter(){
		showHelpText ();
	}
	void OnMouseExit(){
		helpText.text = "";
	}

}
