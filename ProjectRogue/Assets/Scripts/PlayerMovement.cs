using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using DG.Tweening;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpDelay;

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

        if ((Input.GetAxis("Jump") == 1.0f) && jumpTimer > jumpDelay) 
        {
            Vector3 JumpForce = new Vector3(0, 200, 0);
            rb.AddForce(JumpForce);
            jumpTimer = 0.0f;

            if (anim) { anim.SetTrigger("JumpTrigger"); }

        }      
    }


}