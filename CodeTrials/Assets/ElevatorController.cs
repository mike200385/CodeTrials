using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

	public Transform startMarker, endMarkerUp, endMarkerDown, midMarker;
	public GameObject player;

	public float upSpeed = .5f;
	public float downSpeed = .15f;

	private float startTime;
	private float elapsedTime;

	private float journeyLengthUp, journeyLengthDown,journeyToOriginFromUp;

	//Bools that are necessary to determine where the player is
	public bool inArea = false; // is the player on the elevator
	public bool up = false; //Is the player on the second floor
	public bool down = false; //Is the player on the sub floor
	public BoolOpsCompletion elevatorFlag, goingUp; //can the player use the elevator and in which direction

	//Need to know which puzzle the player does first to position the cameras in correct depth index.
	public Camera logicalAndCamera, logicalOrCamera;

	// Use this for initialization
	void Start () {
		resetTime (); //call the resetTime function to have startTime begin at 0
		journeyLengthUp = Vector3.Distance(startMarker.position, endMarkerUp.position);
		journeyLengthDown = Vector3.Distance(startMarker.position, endMarkerDown.position);
		journeyToOriginFromUp = Vector3.Distance (midMarker.position, endMarkerUp.position);
	}

	//Call this function whenever the player gets on the elevator to ensure the elevator movement speed is
	//consistent.
	void resetTime(){
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () { 
		//Determines travel speed of elevator
		elapsedTime = Time.time - startTime; 

		//to prevent the player from bouncing around and having the elevator stop periodically, the players
		//transform position must be the child of the elevator
		if (inArea) { 
			player.transform.parent = this.transform;
		}

		//If the player is going up or down, the elevator goes that way. Also determine which challenge puzzle
		//will be activated first.
		if (inArea && elevatorFlag.useElevator && !up && !down) {
			if (goingUp.goingUp) {
				float distCovered = elapsedTime * upSpeed;
				float fracJourney = distCovered / journeyLengthUp;
				transform.position = Vector3.Lerp (startMarker.position, endMarkerUp.position, fracJourney);
				logicalAndCamera.depth = -2;
				logicalOrCamera.depth = -3;
			} else if (!goingUp.goingUp && !up) {
				float distCovered = elapsedTime * downSpeed;
				float fracJourney = distCovered / journeyLengthDown;
				transform.position = Vector3.Lerp (startMarker.position, endMarkerDown.position, fracJourney);
				logicalOrCamera.depth = -2;
				logicalAndCamera.depth = -3;
			}
		} 

		//Check my positions and set them for which floor I am in and set the flags.
		if (player.transform.position.y > 13.5f && !inArea) {
			up = true; //The player is on the second floor and has exited the elevator.
		}
		if(player.transform.position.y < -15.0f && !inArea){
			down = true; //The player is on the Sub floor and has exited the elevator
		}

		//And then return to the starting floor. 
		if (inArea && up) { //the player has gone back to the elevator from the second floor
			float distCovered = elapsedTime * downSpeed;
			float fracJourney = distCovered / journeyLengthUp;
			transform.position = Vector3.Lerp (transform.position, midMarker.position, fracJourney/2);
		} else if (inArea && down) { //the player has gone back to elevator from sub floor
			float distCovered = elapsedTime * upSpeed;
			float fracJourney = distCovered / journeyLengthDown;
			transform.position = Vector3.Lerp (transform.position, midMarker.position, fracJourney/2);
		}
	}

	//set inArea flag true and reset the timer for elevator for consistent elevator motion.
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//set the flag
			inArea = true;
			resetTime ();
		}
	}
		
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			inArea = false;
		}
	}
}
