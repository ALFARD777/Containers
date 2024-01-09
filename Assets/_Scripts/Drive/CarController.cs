using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CarController : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float deceleration = 10.0f;
    public float maxSpeed = 10.0f;
    public float turnSpeed = 2.0f;
    public static float currentSpeed = 0.0f;
    public Transform car;
    public Text speedometer;
    public static bool goBack = false;
    private void Update()
    {
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        speedometer.text = Convert.ToInt32(currentSpeed).ToString();
        if (goBack) maxSpeed = 8f;
        else maxSpeed = 152f;
        if (!goBack) transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        else transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
        if (transform.position.y > 1) transform.Translate(0, -0.20f, 0);
    }
    public void Accelerate()
    {
        currentSpeed += acceleration * Time.deltaTime;
    }
    public void Decelerate()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, 0f, deceleration * Time.deltaTime);
        if (currentSpeed < 15f) currentSpeed = Mathf.Lerp(currentSpeed, 0f, deceleration * 2 * Time.deltaTime);
    }
    public void Steer(float angle)
    {
        transform.Rotate(Vector3.up, angle * turnSpeed);
    }
}
