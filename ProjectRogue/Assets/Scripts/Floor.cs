using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour {

    private bool hasDropped = false;
    private bool covered = false;
	
	public bool HasFloorDropped()
	{
		//Debug.Log ("Check if floor has dropped");
		//Debug.Log (hasDropped);
		return hasDropped;
	}

	public void SetFloorHasDropped(bool b)
	{
		hasDropped = b;
	}

    public bool IsCovered()
    {
        return covered;
    }

	public void MoveDown(GameObject b)
	{
        if (!hasDropped)
        {
            transform.DOMove(new Vector3(transform.position.x, -20.0f, transform.position.z), 1.0f).OnComplete(() => Destroy(b.gameObject));
            //hasDropped = true;
        }
    }

	public void MoveDown()
	{
        if (!hasDropped)
        {
            transform.DOMove(new Vector3(transform.position.x, -20.0f, transform.position.z), 1.0f);
            //hasDropped = true;
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<MovingWall>())
        {
            if (col.gameObject.GetComponent<MovingWall>().IsWallOutOfPosition())
            {
                covered = true;
                //Debug.Log(this.name + "is covered");
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.GetComponent<MovingWall>())
        {
        //    if (col.gameObject.GetComponent<MovingWall>().IsWallOutOfPosition())
        //    {
                covered = false;
               // Debug.Log(this.name + "is NOT covered");
         //   }        
        }
    }
}
