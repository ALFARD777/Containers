using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class Gaz : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform GazTransform;
    public CarController car;
    private bool isPressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        GazTransform.rotation = Quaternion.Euler(-25, 0, 0);
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        GazTransform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {
        if (isPressed)
        {
            car.Accelerate();
            if (CarController.currentSpeed > 0) CarController.goBack = false;
        }
        else
        {
            car.Decelerate();
            if (CarController.currentSpeed < 0) CarController.goBack = true;
        }
    }
}
