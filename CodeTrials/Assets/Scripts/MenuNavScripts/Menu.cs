using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene ("scene3.0");
	}

	public void GetDirections(){
		SceneManager.LoadScene ("directions");
	}

	public void MainMenuGame(){
		SceneManager.LoadScene("MainMenu");
	}

	public void HighScores(){
		SceneManager.LoadScene ("highscores");
	}


	public void QuitGame(){
		SceneManager.LoadScene("highscoreSaver");
	}

}
