using UnityEngine;
using System.Collections;

public class reactToInt : MonoBehaviour {

	private AudioSource correct;
	public GameObject completedTileOne;
	public GameObject completedTileTwo;
	public GameObject completedTileThree;
	public bool successOne = false;
	public bool successTwo = false;
	public bool successThree = false;


	// Use this for initialization
	void Start () {
		correct = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "1" && !successOne && !successTwo && !successThree) {
			correct.Play ();
			SpriteRenderer.Instantiate (completedTileOne, new Vector3 (346f, 479f, 0), Quaternion.identity);
			other.gameObject.SetActive (false);
			successOne = true;
		}

		if (other.tag == "2" && !successOne && !successTwo && !successThree) {
			correct.Play ();
			SpriteRenderer.Instantiate (completedTileTwo, new Vector3 (346f, 479f, 0), Quaternion.identity);
			other.gameObject.SetActive (false);
			successTwo = true;
		}

		if (other.tag == "3" && !successOne && !successTwo && !successThree) {
			correct.Play ();
			SpriteRenderer.Instantiate (completedTileThree, new Vector3 (346f, 479f, 0), Quaternion.identity);
			other.gameObject.SetActive (false);
			successThree = true;
		}
	}

}
