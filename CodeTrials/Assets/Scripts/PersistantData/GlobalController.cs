using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalController : MonoBehaviour {

	public static GlobalController Instance;
	//Teleporter Room Bools
	public bool arrayPortalActive = false;
	public bool loopPortalActive = false;

	//Camera variables
	public Camera mainCam;
	public Camera secondCam;
	public bool onMainCam;
	public string camName;


	//Loop Level Completion Bools
	public bool singleForLoopComplete = false;
	public bool nestedForLoopComplete = false;
	public bool whileLoopComplete = false;

	//Conditional Level Completion Bools
	public bool boolOpsComplete = false;
	public bool logicalOrComplete = false;
	public bool logicalAndComplete = false;

	//IndentPuzzle Completion
	public bool indentComplete = false;

	public PlayerMovement thePlayer;

	public Transform glPlayerPos; //global player pos for scene transitions

	public Text scoreText, scientistText;
	public int score; // used to track the player's score
	public int scientistCount;
	public int scrAdditive; // what is added or subtracted from the score

	public Text wordDisplay;

	void Awake(){
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}
	}

	void Start(){
		//thePlayer = FindObjectOfType<PlayerMovement> ();
		onMainCam = true;
		camName = mainCam.name;
		score = 0;
		scientistCount = 0;
		scrAdditive = 100;
		scoreText.text = "Score: " + score;
		wordDisplay = GameObject.Find ("WordDisplayer").GetComponent<Text>();
	}

	void Update(){
		//if word display is open because text isn't empty
		if (!wordDisplay.text.Equals ("")) {
			//pressing x will close and clear the box
			if (Input.GetKeyDown (KeyCode.X)) {
				wordDisplay.text = "";
				//unpause
				Time.timeScale = 1.0f;
			}
		}
	}

	//save the players position for use between scenes
	public void savePlayerPos(){
		//glPlayerPos.position = thePlayer.transform.position;
	}
	//changes the scene based on the name
	public void changeScene(string sceneName){

		SceneManager.LoadScene (sceneName);

	}
	//toggles between the main camera and the specified second camera	
	public void toggleCamera(){
		if (onMainCam) {
			mainCam.enabled = false;
			secondCam.enabled = true;
			camName = secondCam.name;
			onMainCam = !onMainCam;
		}
		else if (!onMainCam) {
			mainCam.enabled = true;
			secondCam.enabled = false;
			onMainCam = !onMainCam;
			camName = mainCam.name;
		}
	}
	//changes the second camera in order to allow togling between multiple camera
	public void changeSecondCamera(Camera newCam){
		secondCam = newCam;
	}

	public void incScore(){
		score += scrAdditive;
		scoreText.text = "Score: " + score;
	}

	public void incScientist(){
		scientistCount += 1;
		scientistText.text = "x " + scientistCount;
	}

	public void decScore(){
		score -= scrAdditive;
	}
	public void incAdditive(){
		scrAdditive += 10;
	}
	public void decAdditive(){
		scrAdditive -= 10;
	}
	public void resetAdditive(){
		scrAdditive = 100;
	}
}
