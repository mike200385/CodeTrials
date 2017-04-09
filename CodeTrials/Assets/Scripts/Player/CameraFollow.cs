using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector3 playerTransform;
	private float cameraTransformX;
	private float cameraTransformY;
	private Vector3 cameraVector;
	private Vector3 playerVector;
	public float cameraSpeed;

	void Update () 
	{
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform.position;
		cameraTransformX = transform.position.x;
		cameraTransformY = transform.position.y;
		cameraVector = new Vector3 (cameraTransformX, cameraTransformY, -20);
		playerVector = new Vector3 (playerTransform.x, playerTransform.y, -20);
		transform.position = Vector3.Lerp (cameraVector, playerVector, cameraSpeed * Time.deltaTime);
	}
}