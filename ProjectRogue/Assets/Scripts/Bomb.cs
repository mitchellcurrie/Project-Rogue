using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb : MonoBehaviour {

	private Floor floorPiece;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void BlowUp()
	{
		Debug.Log ("Blow up called");

		if (floorPiece) 
		{
			floorPiece.MoveDown ();
			floorPiece.SetFloorHasDropped (true);
			Debug.Log ("Floor moved down");
		}

		Debug.Log ("Floor not set so not destroyed");
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent<Floor> ()) 
		{
			floorPiece = col.gameObject.GetComponent<Floor> ();
			Debug.Log ("Floor piece set");
		}

		if (col.gameObject.GetComponent<Bomb> ()) 
		{
			if (floorPiece) 
			{
				floorPiece.MoveDown(this);
				floorPiece.SetFloorHasDropped (true);
				Destroy (col.gameObject);
				this.gameObject.SetActive (false);
			}


		}
	}
}
