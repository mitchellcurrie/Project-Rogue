using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCameraController : MonoBehaviour {

	// Use this for initialization
	private Vector3 startingPoint;
	private const float moveSpeed = 10.0f;
	void Start () {
		
		startingPoint = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.RotateAround(Vector3.zero,new Vector3(0,1,0), moveSpeed * Time.deltaTime);	
	}
}
