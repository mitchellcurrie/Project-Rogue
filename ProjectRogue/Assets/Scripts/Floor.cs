using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
		Debug.Log ("Check if floor has dropped");
		Debug.Log (hasDropped);
		return hasDropped;
	}

	public void SetFloorHasDropped(bool b)
	{
		hasDropped = b;
	}

	public void MoveDown(Bomb b)
	{
		transform.DOMove (new Vector3 (transform.position.x, -20.0f, transform.position.z), 1.0f).OnComplete(()=>Destroy (b.gameObject));
		//hasDropped = true;
	}

	public void MoveDown()
	{
		transform.DOMove (new Vector3 (transform.position.x, -20.0f, transform.position.z), 1.0f);
		//hasDropped = true;
	}
}
