﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb : MonoBehaviour {

    private float timer = 0.0f;
    private float timeToShake = 3.0f;
    private float timeToExplode = 5.0f;
    private bool isShaking = false;
    private Floor floorPiece;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timer += Time.deltaTime;

        if (timer > timeToShake && !isShaking)
        {
            isShaking = true;
        }

        if (isShaking)
        {
            Shake();
        }

        if (timer > timeToExplode)
        {
            BlowUp();
        }
    }

	public void BlowUp()
    { 
        Debug.Log ("Blow up called");

       // this.gameObject.SetActive(false);
        Destroy(this.gameObject);

        if (floorPiece) 
		{
			floorPiece.MoveDown ();
			floorPiece.SetFloorHasDropped (true);
			Debug.Log ("Floor moved down");
		}

		Debug.Log ("Floor not set so not destroyed");

       // Destroy(this);
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent<Floor> ()) 
		{
			floorPiece = col.gameObject.GetComponent<Floor> ();
			Debug.Log ("Floor piece set");
        }

		else if (col.gameObject.GetComponent<Bomb> () || col.gameObject.GetComponent<Item>()) 
		{
			if (floorPiece) 
			{
				Destroy (col.gameObject);
                BlowUp();
			}

           if (col.gameObject.GetComponent<Item>())
            {
                Debug.Log("Bomb collision with Orb");
            }
        }
	}

    private void Shake()
    {   //                        Duration                     Strength  Vibrato  Randomness  Fade Out
        transform.DOShakeRotation(timeToExplode - timeToShake, 100,      2,       20,         false);        
        transform.DORotate(new Vector3(0.0f, Random.Range(-360.0f, 360.0f), 0.0f), timeToExplode - timeToShake, RotateMode.Fast);
    }
}
