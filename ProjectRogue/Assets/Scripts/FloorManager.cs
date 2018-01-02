using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

	public GameObject Bomb;
	private Floor[] floorArray;
	private float bombTimer;
	public float bombSpawnTime;
	private float dropHeight;

	// Use this for initialization
	void Start ()
	{
		floorArray = GetComponentsInChildren<Floor>();
		dropHeight = 20.0f;
	}
	
	void FixedUpdate ()
	{
		bombTimer += Time.deltaTime;

		if (bombTimer > bombSpawnTime)
		{
			SpawnBomb();
			bombTimer = 0.0f;
		}
	}

	void SpawnBomb()
	{
		int random = Random.Range(0, floorArray.Length);

		if (!(floorArray[random].HasFloorDropped()))
		{
			Vector3 spawnLocation = floorArray [random].transform.position + new Vector3 (0, dropHeight, 0);
			Instantiate (Bomb, spawnLocation, Quaternion.Euler(0.0f, Random.Range(0, 360), 0.0f)); 
		}
	}  

    public Vector3 GetRandomFloorPosition()
    {
        int random = Random.Range(0, floorArray.Length);
        return floorArray[random].transform.position;
    }

}
