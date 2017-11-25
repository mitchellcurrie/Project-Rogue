using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Animator anim;
    private Vector3 velocity;
    private Vector3 moveDirection;
    private Camera cam;


    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update()
    {

	}

    void FixedUpdate()
    {   
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;
        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDirection = (h * right + v * forward);
        moveDirection *= speed;

        transform.position += moveDirection * Time.deltaTime;

        if (h!=0 || v!=0)
        {
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, 0.3f);
            if (anim) { anim.SetBool("IsWalking", true); }
        }
        else
        {
            if (anim) { anim.SetBool("IsWalking", false); }
        }

        ////////   Basic  //////// 

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //transform.position += (movement * speed * 0.01f);

        ////////   End Basic  //////// 


        ////////   Moving where camera is looking   //////// 

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        ////transform.position += (movement * speed);

        //Vector3 CameraToPlayer = transform.position - cam.transform.position;
        //CameraToPlayer.y = 0.0f;
        //Vector3 CameraToPlayerNorm = Vector3.Normalize(CameraToPlayer);
        //Debug.Log(CameraToPlayerNorm);

        //transform.position += (CameraToPlayerNorm * 0.01f) * moveVertical * speed;

        //if (moveVertical > 0)
        //{
        //    transform.forward = CameraToPlayer;
        //}
        //else if (moveVertical < 0)
        //{
        //    transform.forward = -CameraToPlayer;
        //}

        ////////   End Moving where camera is looking   //////// 

    }
}
