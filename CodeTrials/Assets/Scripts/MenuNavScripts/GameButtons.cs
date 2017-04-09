﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour {

	//public GameObject[] showIfPaused;
	//public GameObject[] showIfResumed;

	// Use this for initialization
	void Start () {

//		//populate array with relevant objects to show when game is paused
//		showIfPaused = GameObject.FindGameObjectsWithTag("WhenPaused");
//		foreach (GameObject psed in showIfPaused)
//			psed.SetActive (false);
//
//		//populate array with relevant objects to show when game is in play/resumed
//		showIfResumed = GameObject.FindGameObjectsWithTag("WhenResumed");
//		foreach (GameObject resmd in showIfResumed)
//			resmd.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		//        if (GameObject.FindGameObjectWithTag("WordDisplay") != null)
		//        {
		//            if (!string.IsNullOrEmpty(GameObject.FindGameObjectWithTag("WordDisplay").GetComponent<Text>().text.Trim()) &&
		//                Input.GetKeyDown("x"))
		//            {
		//                ClearWordDisplay();
		//            }
		//        }
	}

	public void PauseGame(){
		Time.timeScale = 0.0f;


//		foreach (GameObject psed in showIfPaused)
//			psed.SetActive (true);
//
//
//		foreach (GameObject resmd in showIfResumed)
//			resmd.SetActive (false);
	}

	public void ResumeGame(){
		Time.timeScale = 1.0f;

//		foreach (GameObject psed in showIfPaused)
//			psed.SetActive (false);
//
//		foreach (GameObject resmd in showIfResumed)
//			resmd.SetActive (true);
	}

	public void ClearWordDisplay() {
		GameObject.FindGameObjectWithTag ("JITDisplay").GetComponent<Text> ().text = "";

		ResumeGame ();
	}
	public void Menu()
	{
		SceneManager.LoadScene ("Menu");
	}


}
