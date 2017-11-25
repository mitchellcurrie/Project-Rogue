using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallManager : MonoBehaviour {

    private MovingWall[] wallArray;
    private float wallTimer;
    
    // Use this for initialization
	void Start ()
    {
        wallArray = GetComponentsInChildren<MovingWall>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        wallTimer += Time.deltaTime;

        if (wallTimer > 5.0f)
        {
            StartRandomWallMoving();
            wallTimer = 0.0f;
        }

        for (int i = 0; i < wallArray.Length; i++)
        {
            if (wallArray[i].GetIsMoving())
            {
                wallArray[i].MoveIn();
            }
        }
    }

    void StartRandomWallMoving()
    {
        int random = Random.Range(0, wallArray.Length - 1);

        while (wallArray[random].GetIsMoving() == false)
        {
            random = Random.Range(0, wallArray.Length - 1);
        }

        wallArray[random].SetIsMoving(true);

        Debug.Log("New Wall Moving");
    }   
}
