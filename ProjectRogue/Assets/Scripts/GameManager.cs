using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public GameManager GMinstance = null;
    private float gameTimer;
	private bool gamePlaying;
    private enum GameState { MENU, GAME, GAMEOVER };
    private GameState CurrentState;
    private TextManager TM;

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
            TM.SetTimerText("You survived for " + intTimer.ToString() + " seconds!");
        }
    }

    public void GameOver()
    {        
        CurrentState = GameState.GAMEOVER;
        SceneManager.LoadScene("GameOver");
        TM = null;
        Cursor.visible = true;
    }

    public void ResetGame()
    {
        TM = null;
        gameTimer = 0.0f;
        CurrentState = GameState.GAME;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
