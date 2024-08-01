using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouseollow : MonoBehaviour
{
    
    public float lookXLimit = 45f;

    public float lookYLimit = 90;

    float rotationX = 0f;

    float rotationY = 0f;

    public float sensitivity = 15f;


    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        rotationX = Mathf.Clamp(rotationX, - lookXLimit, lookXLimit);
        rotationY = Mathf.Clamp(rotationY, - lookYLimit, lookYLimit);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
