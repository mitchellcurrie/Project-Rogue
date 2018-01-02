using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using DG.Tweening;
using XboxCtrlrInput;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpDelay;
    public float jumpUpPower;
    public float jumpForwardPower;

    private Animator anim;
    private Vector3 velocity;
    private Vector3 moveDirection;
    private Camera cam;

    private Rigidbody rb;
    private float jumpTimer;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        jumpTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update()
    {
       
	}

    void FixedUpdate()
    {
        // Movement
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;
        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h == 0 && v == 0)
        {
            //h = XCI.GetAxisRaw(XboxAxis.LeftStickX);
            //v = XCI.GetAxisRaw(XboxAxis.LeftStickY);
        }
          
        moveDirection = (h * right + v * forward);
        moveDirection *= speed;

        transform.position += moveDirection * Time.deltaTime;

        if (h!=0 || v!=0)
        {
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, 0.3f);
            if (anim) { anim.SetBool("IsRunning", true); }
        }
        else
        {
            if (anim) { anim.SetBool("IsRunning", false); }
        }

        // Jumping

        jumpTimer += Time.deltaTime;

        //if (((Input.GetAxis("Jump") == 1.0f) || XCI.GetButtonDown(XboxButton.A)) && jumpTimer > jumpDelay) 
		if (((Input.GetAxis("Jump") == 1.0f)) && jumpTimer > jumpDelay)
        {
            Vector3 jumpForce = new Vector3(0, jumpUpPower, 0);

            if (transform.position.y < -3.0f)
            {
                jumpForce *= 3.0f;
            }

            rb.AddForce(jumpForce + Vector3.Normalize(transform.forward) * jumpForwardPower);
            jumpTimer = 0.0f;

            if (anim) { anim.SetTrigger("JumpTrigger"); }
        }      
    }


}