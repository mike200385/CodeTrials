using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P2 : MonoBehaviour {
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
		help.text = "A switch statement acts like a series of 'if then' statements that \n" +
		"allow programmers to change states given certain conditions called cases. \n" +
		"You determine which condition to switch on. For instance, if your switch condition \nis a 1 " +
		"then the statement will enter 'case 1'.";
	}

	public void showTextTwo(){
		help.text = "However, switch statements exhibit a behavior called 'fallthrough' which means\n" +
			"that if you don't place a 'break' statement in your program, every case below the one\n" +
			"you are switching on will execute, until you get to the end of your switch statement.";
	}

	public void showTextThree(){
		help.text = "Here we can use this to our advantage, certainly to open only door 1, we\n" +
			"could say the switch condition is 1 and we 'break' after the first case, but there\n" +
			"are several different ways to exploit the uses of the switch statement. Try them!";
	}



	void removeText(){
		help.text = "";
	}
}
