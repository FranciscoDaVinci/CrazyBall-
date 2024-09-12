using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image backGround;
    private Image joyStick;

    public Vector3 InputDirection { set; get; }
    
   private void Start()
    {
        backGround = GetComponent<Image> ();
        joyStick = GetComponentInChildren<Image> ();
        InputDirection = Vector3.zero;
    } 

    public void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle
            (backGround.rectTransform,
            ped.position,
            ped.pressEventCamera,
            out pos))
        {
            pos.x = (pos.x / backGround.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backGround.rectTransform.sizeDelta.y);

            float x = (backGround.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (backGround.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection; 

            joyStick.rectTransform.anchoredPosition =
                new Vector3(InputDirection.x * (backGround.rectTransform.sizeDelta.x / 2)
                , InputDirection.z * (backGround.rectTransform.sizeDelta.y / 2));

        }
    }
  public void OnPointerUp(PointerEventData ped)
    {
        InputDirection = Vector3.zero;
        joyStick.rectTransform.anchoredPosition = Vector3.zero;
    }
    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
