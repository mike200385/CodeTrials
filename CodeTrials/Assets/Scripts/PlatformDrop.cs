//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class PlatformDrop : MonoBehaviour {
//
//
//	public GameObject boxPlatform1;
//
//	private float y = 2.32f;
//	private float x1 = 24.3f;
//	private float beGone = 300f;
//
//
//	// Use this for initialization
//	void Start () {
//		//Plaform 1 Control
//		if (!GlobalController.Instance.box0) {
//			Instantiate (boxPlatform1, new Vector3 (x1, y, 0f), Quaternion.identity);
//		} else {
//			Instantiate (boxPlatform1, new Vector3 (beGone, 2.32f, 0f), Quaternion.identity);
//		}
//
//		if (!GlobalController.Instance.box1) {
//			Instantiate (boxPlatform1, new Vector3 (x1 + 4.15f, y, 0f), Quaternion.identity);
//		} else {
//			Instantiate (boxPlatform1, new Vector3 (beGone, 2.32f, 0f), Quaternion.identity);
//		}
//
//		if (!GlobalController.Instance.box2) {
//			Instantiate (boxPlatform1, new Vector3 (x1 + 8.15f, y, 0f), Quaternion.identity);
//		} else {
//			Instantiate (boxPlatform1, new Vector3 (beGone, 2.32f, 0f), Quaternion.identity);
//		}
//
//		if (!GlobalController.Instance.box3) {
//			Instantiate (boxPlatform1, new Vector3 (x1 + 12.15f, y, 0f), Quaternion.identity);
//		} else {
//			Instantiate (boxPlatform1, new Vector3 (beGone, 2.32f, 0f), Quaternion.identity);
//		}
//
//		if (!GlobalController.Instance.box4) {
//			Instantiate (boxPlatform1, new Vector3 (x1 + 16.15f, y, 0f), Quaternion.identity);
//		} else {
//			Instantiate (boxPlatform1, new Vector3 (beGone, 2.32f, 0f), Quaternion.identity);
//		}
//
//		if (!GlobalController.Instance.box5) {
//			Instantiate (boxPlatform1, new Vector3 (x1 + 20.15f, y, 0f), Quaternion.identity);
//		} else {
//			Instantiate (boxPlatform1, new Vector3 (beGone, 2.32f, 0f), Quaternion.identity);
//		}
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//}
