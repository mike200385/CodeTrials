using UnityEngine;
using System.Collections;

public class ReactToPlusP4 : MonoBehaviour {

	public GameObject completedTile;
	public bool success;


	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "+" && !success) {
			SpriteRenderer.Instantiate (completedTile, this.transform.position, Quaternion.identity);
			other.gameObject.SetActive (false);
			success = true;
		}
	}
}