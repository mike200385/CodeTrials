using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {

	public static RespawnController Instance;

	public Vector3 respawnPos;
	public GameObject objToRespawnAt;
	public PlayerMovement player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMovement> ();
		respawnPos = objToRespawnAt.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void respawnPlayer(){
		player.transform.position = respawnPos;
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Player")){
			respawnPlayer();
		}
	}
}
