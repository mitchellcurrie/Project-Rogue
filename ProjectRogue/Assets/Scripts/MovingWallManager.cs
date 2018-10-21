using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallManager : MonoBehaviour {

    [Range(0,10.0f)]
    public float wallSpawnTime;
    private MovingWall[] wallArray;
    private float wallTimer;


    // Use this for initialization
    void Start ()
    {
        wallArray = GetComponentsInChildren<MovingWall>();
        wallTimer = 0.0f;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        wallTimer += Time.deltaTime;

        if (wallTimer > wallSpawnTime)
        {
            StartRandomWallMoving();
            wallTimer = 0.0f;
        }
    }

    void StartRandomWallMoving()
    {
        int random = Random.Range(0, wallArray.Length);

        if (!wallArray[random].IsWallOutOfPosition())
        {
            wallArray[random].SetIsMovingIn(true);
        }
    }   
}
