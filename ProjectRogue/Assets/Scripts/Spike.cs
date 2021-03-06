﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
	
	public bool isLowering = false;
	public bool isRising = false;
	private const float movementSpeed = 0.1f;
	private float startY;
	private const float endY = -1.0f;
	private const float resetTime = 7.0f;

	// Use this for initialization
	void Start () {
		
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (isLowering)
		{
			Lower();
		}

		else if (isRising)
		{
			Rise();
		}
	}

	public void Lower()
	{
		transform.Translate(0,0,-1 * Time.deltaTime * movementSpeed);

		if (transform.position.y <= endY)
		{
			isLowering = false;
			StartCoroutine("ResetSpike");
		}
	}

	public void Rise()
	{
		transform.Translate(0,0,1 * Time.deltaTime * movementSpeed);

		if (transform.position.y >= startY)
		{
			isRising = false;
		}
	}

	IEnumerator ResetSpike()
	{
		yield return new WaitForSeconds(resetTime);

		isRising = true;
	}	
}
