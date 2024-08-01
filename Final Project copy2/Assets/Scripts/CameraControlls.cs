using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour
{
    public GameObject target;

    public Vector3 posOffset;

    void start()
    {
        posOffset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.transform.position + posOffset;
        }
    }
}