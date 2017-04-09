//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class ArrayReactionTwo : MonoBehaviour {
//
//	public GameObject completedTile0;
//	public GameObject completedTile1;
//	public GameObject completedTile2;
//	public GameObject completedTile3;
//	public GameObject completedTile4;
//	public GameObject completedTile5;
//	public bool success = false;
//
//
//	// Use this for initialization
//	void Start () {
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//	}
//
//	void OnTriggerEnter2D (Collider2D other){
//		
//		if (other.tag == "Array0" && !success) {
//			GlobalController.Instance.box0 = true;
//			SpriteRenderer.Instantiate (completedTile0, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);
//			success = true;
//		}
//		else if(other.tag == "Array1" && !success){
//			GlobalController.Instance.box1 = true;
//			SpriteRenderer.Instantiate (completedTile1, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);
//			success = true;
//		}
//
//		else if(other.tag == "Array2" && !success){
//			GlobalController.Instance.box2 = true;
//			SpriteRenderer.Instantiate (completedTile2, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);
//			success = true;
//		}
//
//		else if(other.tag == "Array3" && !success){
//			GlobalController.Instance.box3 = true;
//			SpriteRenderer.Instantiate (completedTile3, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);
//			success = true;
//		}
//
//		else if(other.tag == "Array4" && !success){
//			GlobalController.Instance.box4 = true;
//			SpriteRenderer.Instantiate (completedTile4, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);
//			success = true;
//		}
//
//		else if(other.tag == "Array5" && !success){
//			GlobalController.Instance.box5 = true;
//			SpriteRenderer.Instantiate (completedTile5, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);
//			success = true;
//		}
//
//
//	}
//}