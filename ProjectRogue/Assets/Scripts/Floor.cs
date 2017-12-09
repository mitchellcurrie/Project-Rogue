using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	private bool hasDropped;

	// Use this for initialization
	void Start () 
	{
		hasDropped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool HasFloorDropped()
	{
		return hasDropped;
	}
}
