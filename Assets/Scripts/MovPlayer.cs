using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPlayer : MonoBehaviour, IObserverButtons
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    //[SerializeField] private float gravityMultipler = 3.0f;
    [SerializeField] VirtualJoystick moveJoystick;

    public float gravity = 9.8f;
    private float velocity;

    IObservableButtons _obsButtons;

    private Rigidbody controller;
    private Transform camTransform;

    public void Awake()
    {
        _obsButtons = GetComponent<IObservableButtons>();
        if (_obsButtons != null)
        {
            _obsButtons.Suscribe(this);
        }
    }

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        Movement();
        Gravity();
    }

    private void Movement()
    {
        Vector3 dirX = Vector3.zero;
        Vector3 dirZ = Vector3.zero;
        Vector3 dir = Vector3.zero;

        //dir.x = Input.GetAxis("Horizontal");
        dirX = camTransform.right * Input.GetAxis("Horizontal");
        //dirZ.z = Input.GetAxis("Vertical");
        dirZ = camTransform.forward * Input.GetAxis("Vertical");
        dir = dirX + dirZ;
        if (dir.magnitude > 1)
            dir.Normalize();
        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir = camTransform.right * moveJoystick.InputDirection.x + camTransform.forward * moveJoystick.InputDirection.z;
        }
        controller.AddForce(dir * moveSpeed);

        /*Vector3 rotateDir = camTransform.TransformDirection(dir);
        rotateDir = new Vector3(rotateDir.x, camTransform.rotation.y, rotateDir.z);
        rotateDir = rotateDir.normalized * dir.magnitude;
        */
    }

    public void PressButton(string button)
    {
        if (button == "Jump")
        {
            Jump();
        }
    }

    public void Jump()
    {
        controller.AddForce(Vector3.up * jumpForce);
    }

    //Ya funciona la gravedad
    private void Gravity()
    {
        controller.AddForce(Vector3.down * gravity);
    }


    //velocity += _gravity * gravityMultipler * Time.deltaTime;
}

