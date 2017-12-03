using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text gameTimerText;
	private float gameTimer;

	private bool gameStarted;

	// Use this for initialization
	void Start () 
	{
		gameStarted = true;


	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (gameStarted) 
		{
			gameTimer += Time.deltaTime;
			int intTimer = (int)gameTimer;
			gameTimerText.text = "Timer: " + intTimer.ToString();
		}
	}
}
