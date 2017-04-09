using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchConsoleBehaviour : MonoBehaviour {

	public Text prompt;
	bool inTrigger = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(inTrigger){
			if (Input.GetKey ("i")) {
				SceneManager.LoadScene ("Scene1.3");
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		inTrigger = true;
		if (other.gameObject.tag == "Player") {
			prompt.text = "Press 'I' to interact";

		}



	}

	void OnTriggerExit2D(Collider2D other){
		inTrigger = false;
		prompt.text = "";
	}
}