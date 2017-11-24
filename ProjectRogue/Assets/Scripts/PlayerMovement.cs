using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Vector3 velocity;
    
    
    // Use this for initialization
	void Start()
    {
      
    }
	
	// Update is called once per frame
	void Update()
    {

	}

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.position += (movement * speed);

    }
}
