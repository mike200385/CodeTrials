 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorLogicConditionals : MonoBehaviour {

	public bool checkFlag;
	public GameObject exitDoor;

	// Use this for initialization
	void Start () {
		checkFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalController.Instance.logicalOrComplete && GlobalController.Instance.logicalAndComplete
		   && !checkFlag) {
			exitDoor.transform.position = new Vector3 (exitDoor.transform.position.x,
				exitDoor.transform.position.y + 5.0f, 0);
			checkFlag = true;
		}
	}
}
