using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    //[SerializeField] Buttons Buttons;
    [SerializeField] VirtualJoystick moveJoystick;

    private Rigidbody controller;
    private Transform camTransform;

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
    }


    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        Vector3 dirX = Vector3.zero;
        Vector3 dirZ = Vector3.zero;
        Vector3 dir = Vector3.zero;

        //dir.x = Input.GetAxis("Horizontal");
        dirX = camTransform.right* Input.GetAxis("Horizontal");


        //dirZ.z = Input.GetAxis("Vertical");
        dirZ = camTransform.forward* Input.GetAxis("Vertical");
        dir = dirX + dirZ;
        if (dir.magnitude > 1)
            dir.Normalize();

        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir = camTransform.right * moveJoystick.InputDirection.x + camTransform.forward * moveJoystick.InputDirection.z;
            //dir = moveJoystick.InputDirection;
        }

        controller.AddForce(dir * moveSpeed);

        /*Vector3 rotateDir = camTransform.TransformDirection(dir);
        rotateDir = new Vector3(rotateDir.x, camTransform.rotation.y, rotateDir.z);
        rotateDir = rotateDir.normalized * dir.magnitude;
        */

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))

            controller.AddForce(Vector3.up * jumpForce);
    }

}
