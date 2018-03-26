using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour {

    public GameManager GM;
    
    // Use this for initialization
	void Start ()
    {
        GM = FindObjectOfType<GameManager>();
    }
	
    public void ResetGame()
    {
        GM.ResetGame();
    }

    public void Quit()
    {
        GM.Quit();
    }
}
