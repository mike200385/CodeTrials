using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackNav : MonoBehaviour {

	public void GoBack(){
		SceneManager.LoadScene ("MainMenu");
	}
}
