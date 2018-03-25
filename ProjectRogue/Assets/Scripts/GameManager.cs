using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public TextMeshProUGUI gameTimerText;
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
			gameTimerText.SetText("Timer: " + intTimer.ToString());
		}
	}

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
