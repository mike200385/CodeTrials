using UnityEngine;
using System.Collections;

public class ReactToTileX : MonoBehaviour {

	private AudioSource correct;
	public GameObject completedTile;
	public bool success = false;


	// Use this for initialization
	void Start () {
		correct = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "x" && !success) {
			correct.Play ();
			SpriteRenderer.Instantiate (completedTile, this.transform.position, Quaternion.identity);
			other.gameObject.SetActive (false);
			success = true;
		}
	}
}
		