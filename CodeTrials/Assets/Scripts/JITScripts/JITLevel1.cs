using UnityEngine;
using System.Collections;

public class JITLevel1 : MonoBehaviour {

	public GameObject jit;

	// Use this for initialization
	void Start () {
	
		jit = GameObject.Find ("HelpNotification");
		Destroy (jit, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
