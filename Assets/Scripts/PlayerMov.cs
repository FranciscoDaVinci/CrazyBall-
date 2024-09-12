using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float roationSpeed = 25.0f;
    public VirtualJoystick moveJoystick;

    private Rigidbody controller;
    private Transform camTransform;

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        controller.maxAngularVelocity = roationSpeed;
        controller.drag = drag;

        camTransform = Camera.main.transform;
    }


    void Update()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (dir.magnitude > 1)
            dir.Normalize();

        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir = moveJoystick.InputDirection;
        }

        controller.AddForce(dir * moveSpeed);

        Vector3 rotateDir = camTransform.TransformDirection(dir);
        rotateDir = new Vector3(rotateDir.x, 0, rotateDir.z);
        rotateDir = rotateDir.normalized * dir.magnitude;
    }
}
