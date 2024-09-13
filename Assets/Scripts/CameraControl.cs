using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform lookAt;

    private Vector3 offset;
    private Vector3 position;

    private Vector2 touchPosition;
    [SerializeField] private float swipeResistance = 200.0f;

    [SerializeField] private float distance = 15.0f;
    [SerializeField] private float yOffset = 3.5f;
    [SerializeField] private float smoothSpeed = 7.5f;

   private void Start()
    {
        offset = new Vector3(0, yOffset, -1f * distance);
        yOffset = 0;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            movCamera(true);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            movCamera(false);

        if(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1))
        {
            touchPosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp (0) || Input.GetMouseButtonUp (1))
        {
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            if(Mathf.Abs (swipeForce) > swipeResistance)
            {
                if (swipeForce < 0)
                    movCamera(true);
                else
                    movCamera(false);
            }
        }
    }
    private void FixedUpdate()
    {
        position = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position + Vector3.up * yOffset);
    }

    public void movCamera(bool left)
    {
        if (left)
            offset = Quaternion.Euler(0, 90, 0) * offset;
            
        else
            offset = Quaternion.Euler(0, -90, 0) * offset;
    }
}
