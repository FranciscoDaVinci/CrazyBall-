using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MovPlayer : MonoBehaviour, IObserverButtons
{
    public float moveSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] VirtualJoystick moveJoystick;

    public float gravity;
    public AudioSource audioBall;

    float dashCooldown = 0.5f;
    float nextDashTime = 0f;

    [SerializeField] Rigidbody controller;
    private Transform camTransform;
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
    }

    void Start()
    {
        controller = GetComponent<Rigidbody>();

        if (Camera.main != null)
            camTransform = Camera.main.transform;
    }

    void Update()
    {
        Movement();
        Gravity();
    }

    Vector3 GetDirection()
    {
        Vector3 dirX = camTransform.right * Input.GetAxis("Horizontal");
        Vector3 dirZ = camTransform.forward * Input.GetAxis("Vertical");
        Vector3 dir = dirX + dirZ;

        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir = camTransform.right * moveJoystick.InputDirection.x + camTransform.forward * moveJoystick.InputDirection.z;
        }

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }

    private void Movement()
    {
        Vector3 dir = GetDirection();
        controller.AddForce(dir * moveSpeed);

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
            Jump();

        if (button == "Dash")
            Dash();
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

    public void Dash()
    {

        if (Time.time < nextDashTime)
            return;

        if (CanJump())
        {
            nextDashTime = Time.time + dashCooldown;

            Vector3 dir = GetDirection();

            if (dir == Vector3.zero)
                dir = camTransform.forward;

            dir += Vector3.up * 0.3f;
            dir.Normalize();

            controller.AddForce(dir * 15f, ForceMode.Impulse);
        }
    }
}

