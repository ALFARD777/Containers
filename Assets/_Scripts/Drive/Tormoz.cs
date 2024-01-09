using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tormoz : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform TormozTransform;
    public CarController car;
    public float tormozQuality = 6f;
    private bool isPressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        TormozTransform.rotation = Quaternion.Euler(-25, 0, 0);
        if (CarController.currentSpeed > 0.1) car.deceleration *= tormozQuality;
        else CarController.goBack = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        TormozTransform.rotation = Quaternion.Euler(0, 0, 0);
        if (CarController.currentSpeed > 0.1) car.deceleration /= tormozQuality;
    }
    void Update()
    {
        if (isPressed && CarController.goBack)
        {
            car.Accelerate();
        }
        else
        {
            car.Decelerate();
        }
    }
}
