using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

    public bool North;
    public bool South;
    public bool East;
    public bool West;

    private static float movementSpeed = 0.01f;

    public bool IsMovingIn;
    public bool IsMovingOut;
    public bool OutOfPosition;
    public Vector3 movementDirection;
    public Vector3 originalPos;

    private Rigidbody rb;
    private BoxCollider boxCol;

    // Use this for initialization
    void Start ()
    {
        IsMovingIn = false;
        IsMovingOut = false;
        OutOfPosition = false;

        rb = GetComponent<Rigidbody>();
        boxCol = GetComponent<BoxCollider>();

        if (rb && boxCol)
        {
            if (North || South)
            {
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
            else if (East || West)
            {
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
        }

        if (North) { movementDirection = new Vector3(0, 0, -1); }
        else if (South) { movementDirection = new Vector3(0, 0, 1); }
        else if (East) { movementDirection = new Vector3(-1, 0, 0); }
        else if (West) { movementDirection = new Vector3(1, 0, 0); }

        originalPos = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (IsMovingIn) { MoveIn(); }
        else if (IsMovingOut) { MoveOut(); }
        else if (!OutOfPosition)
        {
            transform.position = originalPos;
        }
    }

    public bool IsWallOutOfPosition()
    {
        return OutOfPosition;
    }

    public void MoveIn()
    {
        transform.position += movementDirection * movementSpeed;
        OutOfPosition = true;
    }

    public void MoveOut()
    {
        transform.position -= movementDirection * movementSpeed;

        float XChange = transform.position.x - originalPos.x;
        float ZChange = transform.position.z - originalPos.z;

        if (Mathf.Abs(XChange) < 0.02f && Mathf.Abs(ZChange) < 0.02f)
        {
            //Debug.Log("Current = (" + transform.position.x + "," + transform.position.z + ") Original = (" + originalPos.x + ","+ originalPos.z + ")");
            Debug.Log("X Change = " + XChange + "      Z Change = " + ZChange);

            transform.position = originalPos;
            OutOfPosition = false;
            IsMovingOut = false;
        }
    }

    public void SetIsMovingIn(bool _b)
    {
        IsMovingIn = _b;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<MovingWall>())
        {
            IsMovingIn = false;
            IsMovingOut = false;
            Debug.Log("Collision with wall");
        }
        else if (col.gameObject.GetComponent<PlayerMovement>())
        {
            if (OutOfPosition)
            {
                IsMovingOut = true;
                IsMovingIn = false;
            }
        }
    }

    private void OnCollisionStay(Collision col)
    {
        //IsMoving = false;
    }

}
