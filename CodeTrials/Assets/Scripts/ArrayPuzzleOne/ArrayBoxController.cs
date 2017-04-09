using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayBoxController : MonoBehaviour {

	public int weight; // the weight of the box
	public GameObject underPlatform;
	public bool removePlatform;
	public bool slotOneSuccess;
	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		//createPlatform ();
		initialPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		if (slotOneSuccess) {
//			removePlatform = GlobalController.Instance.box0;
//			dropPlatform ();
//			slotOneSuccess = false;
//		}
		//underPlatform.SetActive(false);
	}

	public int getWeight(){
		return weight;
	}
	 
	public void dropPlatform(){
		underPlatform.SetActive (false);
		//underPlatform.transform.Rotate(new Vector3(0, 0, 90));
	}

	public void createPlatform(){
		Instantiate (underPlatform, (this.transform.position - new Vector3(0.0f, 1.0f, 0.0f)), Quaternion.identity);
	}

	public void resetBox(){
		underPlatform.SetActive (true);
		this.transform.position = initialPosition;
	}

}
