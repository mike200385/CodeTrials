using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackNavR1 : MonoBehaviour {

		// Use this for initialization
		public void GoBack(){
			SceneManager.LoadScene ("SceneBackL1");
		}
	}