using UnityEngine;
using System.Collections;

public class ReacttoXP4 : MonoBehaviour {

	public GameObject completedTile;
	public bool success;
	public TileDrag activate;
	private float tossThis = 1000.0f;

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "x" && !success) {
			SpriteRenderer.Instantiate (completedTile, this.transform.position, Quaternion.identity);
			success = true;
			activate.canIDragit = false;
			other.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, 
				this.transform.position.y + tossThis, 0);
		}
	}

	void Update () {
		if (Input.GetKeyDown("r")) {
			slotReset ();
		}
	}

	void slotReset(){
	}
		
}