﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager GMinstance = null;
    private static float gameTimer;
	private static bool gamePlaying;
    private enum GameState { MENU, GAME, GAMEOVER };
    private static GameState CurrentState;
    public enum CauseOfDeath { LAVA, TIME };
    private static CauseOfDeath CurrentCauseOfDeath;
    private static TextManager TM;

    void Awake ()
    {
        if (GMinstance != null)
        {
            Destroy(gameObject);
        }         
        else
        {
            GMinstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Use this for initialization
    void Start () 
	{
        CurrentState = GameState.GAME;
        TM = FindObjectOfType<TextManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (CurrentState == GameState.GAME) 
		{
            if (!TM)
            {
                TM = FindObjectOfType<TextManager>();
            }

            gameTimer += Time.deltaTime;
			int intTimer = (int)gameTimer;
            TM.SetTimerText("Timer: " + intTimer.ToString());

		}

        else if (CurrentState == GameState.GAMEOVER)
        {
            if (!TM)
            {
                TM = FindObjectOfType<TextManager>();
            }

            int intTimer = (int)gameTimer;
            TM.SetTimerText("You survived for " + intTimer.ToString() + " seconds");

            if (CurrentCauseOfDeath == CauseOfDeath.LAVA)
            {
                TM.SetCODText("You fell into the lava!");
            }
            else // Ran out of time
            {
                TM.SetCODText("You ran out of time!");
            }
           
        }
    }

    public static void GameOver()
    {        
        CurrentState = GameState.GAMEOVER;
        SceneManager.LoadScene("GameOver");
        TM = null;
        Cursor.visible = true;
    }

    public static void SetCauseOfDeath(CauseOfDeath _CauseOfDeath)
    {
        CurrentCauseOfDeath = _CauseOfDeath;
    }

    public static CauseOfDeath GetCauseOfDeath()
    {
        return CurrentCauseOfDeath;
    }

    public static void ResetGame()
    {
        TM = null;
        gameTimer = 0.0f;
        CurrentState = GameState.GAME;
        SceneManager.LoadScene("Game");
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
