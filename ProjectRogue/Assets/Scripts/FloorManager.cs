using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

	private Floor[] floorArray;

	// Use this for initialization
	void Start ()
	{
		floorArray = GetComponentsInChildren<Floor>();
	}
	
    public bool IsAvailableFloorPosition()
    {
        for (int i = 0; i < floorArray.Length; i++)
        {
            if (!(floorArray[i].HasFloorDropped()))
            {
                return true;
            }
        }

        return false;
    }

    public Vector3 GetRandomFloorPosition()
    {
        bool foundPosition = false;
        int random = 0;

        while (!foundPosition)
        {
            random = Random.Range(0, floorArray.Length);

            if (!(floorArray[random].HasFloorDropped()))// && !(floorArray[random].IsCovered()))
            {
                foundPosition = true;
            }
        }

        return floorArray[random].transform.position;
    }
}
