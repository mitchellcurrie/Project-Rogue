using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col)
	{
		
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent<Bomb>())
		{
            Destroy(col.gameObject);
        }
    }

    //Player moving when on a moving wall / platform
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.GetComponent<MovingWall>())
        {
            MovingWall wall = col.gameObject.GetComponent<MovingWall>();
            Vector3 WallMovement = wall.GetDirectionXSpeed();

            if (wall.IsMovingOut)
            {
                WallMovement *= -1;
            }

            if (wall.IsWallOutOfPosition())
            {
                transform.position += WallMovement;
            }         
        }
    }
}
