using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject Player;
    public float Force;
    private Rigidbody controller;

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if (isPressed)
        {
            controller.AddForce(Vector3.up * Force);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
