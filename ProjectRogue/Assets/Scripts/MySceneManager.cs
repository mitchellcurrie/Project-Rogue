using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour {
	
    public void ResetGame()
    {
        GameManager.ResetGame();
    }

    public void Quit()
    {
        GameManager.Quit();
    }
}
