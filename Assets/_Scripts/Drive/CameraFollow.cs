using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carTransform;
    public float rotationSpeed = 5.0f;
    public Vector3 offset = new Vector3(0f, 2f, -5f);

    void LateUpdate()
    {
        if (carTransform != null)
        {
            float desiredAngle = carTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            transform.position = carTransform.position + rotation * offset;

            Quaternion currentRotation = Quaternion.LookRotation(carTransform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
