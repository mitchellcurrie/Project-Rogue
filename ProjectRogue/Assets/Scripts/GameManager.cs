using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager GMinstance = null;
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
            Debug.Log("In Game Part");
            gameTimer += Time.deltaTime;
			int intTimer = (int)gameTimer;
            TM.SetTimerText("Timer: " + intTimer.ToString());
		}

        else if (CurrentState == GameState.GAMEOVER)
        {
            Debug.Log("In GameOver Part");
            int intTimer = (int)gameTimer;
            TM.SetTimerText("You survived for " + intTimer.ToString() + " seconds!");          
        }
    }

    public void GameOver()
    {        
        Debug.Log("Game Over");
        CurrentState = GameState.GAMEOVER;
        SceneManager.LoadScene("GameOver");
        TM = FindObjectOfType<TextManager>();
    }
}
