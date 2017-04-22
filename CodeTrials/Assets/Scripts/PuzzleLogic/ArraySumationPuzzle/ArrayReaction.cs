using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayReaction : MonoBehaviour {

	public bool success;
	public string giveName;
	public AudioSource correct;

	// Use this for initialization
	void Start () {
		success = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		//get name
		//set compTile to that prefab	
		//instantiate
		if (other.CompareTag ("ArrayTile") && !success) {
			//other.GetComponent<TileDrag> ().disableBoxCol ();
			SpriteRenderer.Instantiate ((GameObject)Resources.Load ("ReplacementTile/" + other.GetComponent<ArrayTileController> ().tileName), this.transform.position, Quaternion.identity);
			other.gameObject.SetActive (false);// set the tile to inactive
			other.GetComponent<ArrayTileController> ().isUsed = true;// set flag to tell if this was used
			giveName = other.GetComponent<ArrayTileController> ().tileName;
			success = true;
			correct.Play ();
		}

	}

	public void resetSuccessBool(){
		success = false;
	}


}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class ArrayReaction : MonoBehaviour {
//
//	public GameObject completedTile0;
//	public GameObject completedTile1;
//	public GameObject completedTile2;
//	public GameObject completedTile3;
//	public GameObject completedTile4;
//	public GameObject completedTile5;
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
//		
//		if (other.GetComponent<ArrayTileController>().tileName == "Array0" && !success) {
//			GlobalController.Instance.box0 = true;//set flag
//			//create mini in slott
//			SpriteRenderer.Instantiate (completedTile0, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);// set the tile to inactive
//			other.GetComponent<ArrayTileController> ().isUsed = true;// set flag to tell if this was used
//			success = true;
//		}
//		else if(other.GetComponent<ArrayTileController>().tileName == "Array1" && !success){
//			GlobalController.Instance.box1 = true;//set flag
//			//create mini in slot
//			SpriteRenderer.Instantiate (completedTile1, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);// set the tile to inactive
//			other.GetComponent<ArrayTileController> ().isUsed = true;// set flag to tell if this was used
//			success = true;
//		}
//
//		else if(other.GetComponent<ArrayTileController>().tileName == "Array2" && !success){
//			GlobalController.Instance.box2 = true;//set flag
//			//create mini in slot
//			SpriteRenderer.Instantiate (completedTile2, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);// set the tile to inactive
//			other.GetComponent<ArrayTileController> ().isUsed = true;// set flag to tell if this was used
//			success = true;
//		}
//
//		else if(other.GetComponent<ArrayTileController>().tileName == "Array3" && !success){
//			GlobalController.Instance.box3 = true;//set flag
//			//create mini in slot
//			SpriteRenderer.Instantiate (completedTile3, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);// set the tile to inactive
//			other.GetComponent<ArrayTileController> ().isUsed = true;// set flag to tell if this was used
//			success = true;
//		}
//
//		else if(other.GetComponent<ArrayTileController>().tileName == "Array4" && !success){
//			GlobalController.Instance.box4 = true;//set flag
//			//create mini in slot
//			SpriteRenderer.Instantiate (completedTile4, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false);// set the tile to inactive
//			other.GetComponent<ArrayTileController> ().isUsed = true;// set flag to tell if this was used
//			success = true;
//		}
//
//		else if(other.GetComponent<ArrayTileController>().tileName == "Array5" && !success){
//			GlobalController.Instance.box5 = true; //set flag
//			//create mini in slot
//			SpriteRenderer.Instantiate (completedTile5, this.transform.position, Quaternion.identity);
//			other.gameObject.SetActive (false); // set the tile to inactive
//			other.GetComponent<ArrayTileController> ().isUsed = true; // set flag to tell if this was used
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
