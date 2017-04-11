using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public float moveSpeed; // how fast the player moves 
	public float jumpSpeed; // how high player jumps

	public bool isGrounded; // know if player is on ground
	public bool isJumping; // know if player is jumping

	//variables for checking if player is on ground or not
	public Transform groundCheck;
	public float groundCheckRadius; // radius of ground check space
	public LayerMask whatIsGround;

	private Rigidbody2D myRigidBody; // rigid body used for moving and jumping
	public bool zoom = false; //flag for using Camera ZoomIn/Out functions.

	private Animator anim;
	public Camera cam;

	public GlobalController gameManager;

//Animation States 
	const int STATE_IDLE = 0;
	const int STATE_RIGHT = 1;
	const int STATE_LEFT = 2;
	const int STATE_JUMP = 3;
	int currentAnimState = STATE_IDLE;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> (); // rigid body for physics
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapCircle (groundCheck.position,groundCheckRadius,whatIsGround);
		myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		//Horizontal input is either 0(no input), 1(going right), or -1(going left)

		//checking RIGHT input
		if (Input.GetAxisRaw ("Horizontal") > 0f) {         //don't change y value
			myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (2f, 2f, 1f); // 2 b/c that's the sprites scale
			changeState(STATE_RIGHT);
		} 

		//Checking LEFT input
		else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (2f, 2f, 1f);
			changeState (STATE_LEFT);
		} 
			
		//NO INPUT
		else {
			myRigidBody.velocity = new Vector3 (0f, myRigidBody.velocity.y, 0f);
			changeState(STATE_IDLE);
		}


		// checking jump input(space or up)
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			// put jumpSpeed in y to move up by moveSpeed

			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpSpeed, 0f);
			isJumping = true;
			changeState (STATE_JUMP);
		}
		// if on the ground, set falling and jumping to false
		else if(isGrounded){ 
			
			isJumping = false;

		}
		//allows player to zoom out the camera to see larger section of the map.
		if (Input.GetKeyDown("q")) {
			if (!zoom) {
				zoomOut ();
				zoom = true;
			} else {
				zoomIn ();
				zoom = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			//gameManager.toggleCamera ();
		}
			


	}
	//Function to change animation state controllers. 
		void changeState(int state){
			if (currentAnimState == state) {
				return;
			}
			switch (state) {

				case STATE_RIGHT:
					anim.SetInteger ("state", STATE_RIGHT);
					break;

				case STATE_LEFT:
					anim.SetInteger ("state", STATE_LEFT);
					break;

				case STATE_IDLE:
					anim.SetInteger ("state", STATE_IDLE);
					break;
				
				case STATE_JUMP:
					anim.SetInteger ("state", STATE_JUMP);
					break;
			}

		currentAnimState = state;
	}

	//Changes Camera.cam ortho size on toggle mapped to "Q" key.
	void zoomOut(){
		cam.orthographicSize = 10;
	}
	void zoomIn(){
		cam.orthographicSize = 7;
	}
			
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("ArrayLevel")) {
			// if(Switch is set to correct door, then telepirt player to that level
			GlobalController.Instance.savePlayerPos();
			//GlobalController.Instance.changeScene ("ArrayLevel");
		}

		//if (other.gameObject.CompareTag("RisingPlatform")) {
			//transform.parent = other.transform; // stop making the platform a parent
		//}

	}

	//void OnCollisionExit2D(Collision2D other){
	//	if (other.gameObject.CompareTag("RisingPlatform")) {
	//		transform.parent = null; // stop making the platform a parent
	//	}
	//}
}