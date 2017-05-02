using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JITScript : MonoBehaviour { 
	// JUST IN TIME INSTRUCTIONS

	public Text wordDisplay;
	public string jitName;
	public AudioSource getScientistChime, enterBriefDialogue;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			switch (this.jitName) {

			case "ArrayBriefing":
				wordDisplay.text = "This trial room deals with Arrays! \n" +
				"An array is a list of elements of the same type. \n " +
				"Arrays count their elements starting at 0! Remember that! " +
				"Arrays can be accessed like this: array[num] Where num is a number.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArrayChallenge1":
				wordDisplay.text = "There are 5 elements in this array.\n\n" +
					"Access the First, Third, and Last spots in the array to complete this challenge." +
					"Watch out for weird array indexes";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArrayChallenge2":
				wordDisplay.text = "This challenge is about adding using an array." +
					"Put your coding skills to the test and make the sum equal 14.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				break;
			case "DataTypeBriefing":
				wordDisplay.text = "There's only 1 scientist in here, blocked by 2 doors." +
				"The theme of this room is initialization and arithmetic math. \n \n" +
				"There are many datatypes used in programming such as int, bool, double, string, char, and float. \n" +
				"Ints hold whole numbers, doubles hold decimal values, chars hold single characters, and so on.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "DataTypeChallenge":
				wordDisplay.text = "The code is incomplete! To get past this first door, place the correct datatypes with their variables. You can do it!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArithBriefing":
				wordDisplay.text = "There are 5 main operators that are used: +, -, *, /, and %. \n" +
					"The % operator gives the remainder of a division. So 8 % 3 is 2.\n\n" +
					"Also, remember that the precedence of the operators is (*,/,%), followed by (+,-).";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "ArithChallenge":
				wordDisplay.text = "The code is incomplete! To open the door, set the equation to equal 2, don't give up!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			
			//First generic scientist response
			case "Scientist1":
				wordDisplay.text = "Thanks for saving me! I'll help find a way to escape from the ship!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				playScientistChime ();
				break;
			//Second generic scientis response
			case "Scientist2":
				wordDisplay.text = "Thanks for saving me! Let me help you find an escape route with the others!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				playScientistChime ();
				break;
			case "MidLevelScientistArray":
				//solves camera problem in array level
				wordDisplay.text = "Thanks for saving me! We need to find a way to escape the ship ASAP!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GameObject sci = GameObject.Find ("MidScientist");
				GlobalController.Instance.incScientist ();
				playScientistChime ();
				Destroy (sci,7.0f);
				break;
			
			//CONDITIONAL LEVEL BRIEFINGS
			case "ConditionalBriefing":
				wordDisplay.text = "Three scientists are stuck behind three doors,  \n" +
					"The desktops in this wing operate using conditional logic, complete their code to release the scientists.\n " +
					"Conditional logic is extremely useful in creating if statements and loops.  \n" +
					"Remember these common operators:  \n" +
					"'!' - negation operator. \n '&&' - logical and operator. All conditions in the statement" +
					"must be true. \n '||' - logical or operator. Only one of the conditions need be true.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "BoolOpsBrief":
				wordDisplay.text = "The desktop ahead controls the elevator \n" +
				"and can take you up or down depending on your decision.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "LogicalAndBrief":
				wordDisplay.text = "You have arrived at the Logical And terminal. " +
				"These pylons in the ship's floor must be raised to open the door locking in " +
					"the scientist. Remember the key distinction between AND and OR.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "LogicalOrBrief":
				wordDisplay.text = "You have arrived at the Logical Or terminal. " +
					"These pylons in the ship's floor must be raised to open the door locking in " +
					"the scientist. Remember the key distinction between AND and OR.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "LogicalAndScientistJIT":
				wordDisplay.text = "Thanks for saving me! Let me help you get the ship under control!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				GlobalController.Instance.logicalAndComplete = true;
				playScientistChime ();
				break;
			case "LogicalOrScientistJIT":
				wordDisplay.text = "Thanks for saving me! Let me help you get the ship under control!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				GlobalController.Instance.logicalOrComplete = true;
				playScientistChime ();
				break;
			case "ExitDoorScientistJIT":
				wordDisplay.text = "Good work! Hurry through the portal, there are more like me to be helped!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				GlobalController.Instance.incScientist ();
				playScientistChime ();
				break;

		//LOOP LEVEL JITS
			case "LoopBriefing":
				wordDisplay.text = "Three scientists are stuck behind doors in this sector. \n" +
					"The desktops in this wing require the use of loops to release the door locks. \n" +
					"Loops are vital to programming, they allow you to perform various statements " +
					"a specific number of times. Ahead are desktops for a simple for loop, \n" +
					"a nested for loop and a simple while loop.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "SingleForBrief":
				wordDisplay.text = "You have arrived at the for loop terminal. Take note of the " +
					"number displayed on the door to solve this puzzle. The number given to the terminal" +
					" must match the displayed number on the door. ";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "NestedForBrief":
				wordDisplay.text = "You have arrived at the nested for loop terminal. \n" +
					"Be sure to look at the grid next to the desktop to discover the correct x, y \n" +
					"coordinate which is the passcode for exit.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;

			case "WhileBrief":
				wordDisplay.text = "You have arrived at the while loop terminal. \n" +
					"The scientist is trapped behind the laser, and the laser won't turn off \n" +
					"until the proper condition occurs. Use the desktop to turn off the laser.";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			

			//FINAL LEVEL JITS
			case "FinalBriefing":
				wordDisplay.text = "You're almost there! The rest of the scientists are at the top of this room" +
				"You need to use what you've learned in order to make the sum 10, which will turn on the rising platform! " +
				"This is the final push! Time to finsh what you started!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;
			case "FinalCompletion":
				wordDisplay.text = "You've made it! Thank you so much for rescuing us all!\n" +
					"The malware has spread throughout the ship and we can't get it back!\n" +
					"We're going to eject our escape pod and head back to base. We wouldn't be here without you.\n\n" +
					"Thank you a million times!";
				Time.timeScale = 0.0f;
				Destroy (this.gameObject);
				playDialogue ();
				break;


			//MISC JITS
			case "RaiseBarriers":
				this.gameObject.SetActive(false);
				//Destroy(this.gameObject);
				break;
			case "EscapePod": // launches the escape pod
				this.gameObject.SetActive (false);
//				Destroy(this.gameObject);
				playScientistChime(); // actually plays escape pod launch sound
				playDialogue(); // actually plays escape pod music
				break;
			}
		}
	}

	void playScientistChime(){
		getScientistChime.Play ();
		getScientistChime.loop = false;
	}

	void playDialogue(){
		enterBriefDialogue.Play ();
		getScientistChime.loop = false;
	}
		

}
