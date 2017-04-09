//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class ArrayReactionAccess : MonoBehaviour {
//
//	public bool success;
//
//	// Use this for initialization
//	void Start () {
//		success = false;
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//	}
//
//	void OnTriggerEnter2D (Collider2D other){
//		//get name
//		//set compTile to that prefab
//		//instantiate
//		if (other.CompareTag ("ArrayTile")) {
//			GlobalController.Instance.box0 = true;//set flag
//			GameObject temp = GameObject.Instantiate ((GameObject)Resources.Load ("ReplacementTile/" + other.GetComponent<ArrayTileController> ().tileName), this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);// set the tile to inactive
//			other.GetComponent<ArrayTileController> ().isUsed = true;// set flag to tell if this was used
//			success = true;
//		}
//
//	}
//
//	public void resetSuccessBool(){
//		success = false;
//	}
//
//
//}
