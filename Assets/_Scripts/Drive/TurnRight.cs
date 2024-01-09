using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CarController car;
    public Transform buttonTransform;
    public float rotationSpeed = 4.0f;
    private bool isPressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonTransform.rotation = Quaternion.Euler(-25, 0, 0);
        isPressed = true;
        if (CarController.currentSpeed > 1) RotateRight();
    }

    void RotateRight()
    {
        float angle = rotationSpeed * Time.deltaTime;
        car.Steer(angle);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonTransform.rotation = Quaternion.Euler(0, 0, 0);
        isPressed = false;
    }
    void Update()
    {
        if (isPressed && CarController.currentSpeed > 1)
        {
            RotateRight();
        }
    }
}
