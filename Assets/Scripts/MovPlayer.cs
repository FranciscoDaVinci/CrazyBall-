using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MovPlayer : MonoBehaviour, IObserverButtons
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] VirtualJoystick moveJoystick;

    public float gravity;
    public AudioSource audioBall;


    [SerializeField] Rigidbody controller;
    private Transform camTransform;
    //Vector3 checkPoint;
    private Ray _jumpRay;
    private float _jumpRayDis = 1.25f;

    IObservableButtons _obsButtons;

    public void Awake()
    {
        _obsButtons = GetComponent<IObservableButtons>();
        if (_obsButtons != null)
        {
            _obsButtons.Suscribe(this);
        }
        //checkPoint = transform.position;
    }

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
        //youwinText.SetActive(false);
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

        //Sonido
        if (controller.velocity.magnitude > 0.1f && CanJump())
        {
            audioBall.enabled = true;
        }
        else
        {
            audioBall.enabled = false;
        }
    }

    public void PressButton(string button)
    {
        if (button == "Jump")
        {
            Debug.Log("Deberia estar saltando");
            Jump();
        }
    }

    public void Jump()
    {
        if (CanJump())
        {
            controller.AddForce(Vector3.up * jumpForce);
            Debug.Log("Deberia estar saltando x2");
        }
    }

    public bool CanJump()
    {
        _jumpRay = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.down);
        return Physics.Raycast(_jumpRay, _jumpRayDis);
    }

    private void Gravity()
    {
        controller.AddForce(Vector3.down * gravity);
    }
}

