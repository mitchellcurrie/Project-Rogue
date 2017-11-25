using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

    private bool IsMoving;
    
    // Use this for initialization
	void Start ()
    {
        IsMoving = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MoveIn()
    {
        Vector3 movement = new Vector3(0.01f, 0, 0);
        transform.position += movement;
    }

    public void MoveOut()
    {

    }

    public void SetIsMoving(bool _b)
    {
        IsMoving = _b;
    }

    public bool GetIsMoving()
    {
        return IsMoving;
    }

}
