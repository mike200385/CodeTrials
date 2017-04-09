using UnityEngine;
using System.Collections;

public class TileDrag : MonoBehaviour {

	float x;
	float y;
	float z;

	Vector3 initialPosition;
	public Camera testCam;

	public bool canIDragit = true;

	// Use this for initialization
	void Start () {
		initialPosition = this.transform.position; //store the initial Vector3 location of tile
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnMouseDrag(){
		if (canIDragit) {
			x = Input.mousePosition.x;
			y = Input.mousePosition.y;
			// take the object's Z and correctly adjust it by subtracting the camera's Z
			// this makes up for the odd z translation that sometimes occurs
			z = transform.position.z - testCam.transform.position.z;
			transform.position = testCam.ScreenToWorldPoint (new Vector3 (x, y, z));
		}
	}

	//Reset the initial location of tile when needed.
	public void onReset(){
		this.gameObject.transform.position = initialPosition;
	}

	public void disableBoxCol(){
		this.GetComponent<BoxCollider2D> ().enabled = false;
	}
}
