using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform target;
    public float distance = 10.0f;
    public float sensitivityX = 5.0f;
    public float sensitivityY = 2.0f;

    private Transform camTransform;
    private Camera cam;

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 70.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;


    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY + 10.0f, currentX, 0);
        camTransform.position = target.position + rotation * dir;
        camTransform.LookAt(target.position);
    }
}
