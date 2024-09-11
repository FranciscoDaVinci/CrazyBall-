using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform lookAt;

    private Vector3 offset;
    private Vector3 position;

    private float distance = 15.0f;
    private float yOffset = 3.5f;
    private float smoothSpeed = 7.5f;

   private void Start()
    {
        offset = new Vector3(0, yOffset, -1f * distance);
    }

   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            movCamera(true);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            movCamera(false);
          
        
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
