using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackNavLevel1 : MonoBehaviour {

	// Use this for initialization
	public void GoBack(){
		SceneManager.LoadScene ("Temp1");
	}
}
