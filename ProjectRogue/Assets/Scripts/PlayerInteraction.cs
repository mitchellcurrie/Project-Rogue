﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.GetComponent<Item>())
		{
			Destroy (col.gameObject);
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent<Bomb>())
		{
			Destroy (col.gameObject);
		}
	}
}
