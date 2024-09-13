using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    //[SerializeField] Buttons Buttons;
    [SerializeField] VirtualJoystick moveJoystick;

    private Rigidbody controller;
    //private Transform camTransform;

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        //camTransform = Camera.main.transform;
    }


    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
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

        /*Vector3 rotateDir = camTransform.TransformDirection(dir);
        rotateDir = new Vector3(rotateDir.x, 0, rotateDir.z);
        rotateDir = rotateDir.normalized * dir.magnitude;
        */
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))

            controller.AddForce(Vector3.up * jumpForce);
    }
}
