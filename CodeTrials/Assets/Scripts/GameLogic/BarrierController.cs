using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour {

	public PlayerMovement player;
	public JITScript triggerCollider;
	public GameObject barrierToMove; // object to be moved

	//points that object will move between back and forth
	public Transform endPoint; // ending point
	public float moveSpeed; // how fast the object moves
	private Vector3 currentTarget; // the current point it's going to
	public Vector3 initialPosition; // initial pos of the object

	// Use this for initialization
	void Start () {
		currentTarget = endPoint.transform.position;
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//if it has been deactivated because the player touched it
		if (!triggerCollider.gameObject.activeSelf) { 
			//move the barrier
			moveBarrier ();
		}
		//moveBarrier();
	}

	public void moveBarrier(){
		print ("MOVING BARRIER");
		if (barrierToMove != null) {
			barrierToMove.transform.position = Vector3.MoveTowards (barrierToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
		}
	}

	public void resetPosition(){
		transform.position = initialPosition;
	}

	
}
