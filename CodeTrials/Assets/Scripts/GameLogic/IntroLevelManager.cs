using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLevelManager : MonoBehaviour {

	public GameObject arrayPortal;
	public GameObject loopPortal;
	public float x1 = 48.8f;
	public float x2 = 63.42f;
	public float y = -2.7f;
	// Use this for initialization
	void Start () {
		if (GlobalController.Instance.arrayPortalActive) {
			SpriteRenderer.Instantiate (arrayPortal, new Vector3 (x1, y, 0), Quaternion.identity);
		}
		if (GlobalController.Instance.loopPortalActive) {
			SpriteRenderer.Instantiate (loopPortal, new Vector3 (x2, y, 0), Quaternion.identity);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
