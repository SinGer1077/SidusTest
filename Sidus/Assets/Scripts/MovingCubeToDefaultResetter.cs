using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeToDefaultResetter : MonoBehaviour
{
    private Vector3 _defaultPosition;

    private Vector3 _defaultRotation;

    private void Start()
    {
        _defaultPosition = transform.position;
        _defaultRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _defaultPosition;

            Quaternion defaultQuat = new Quaternion();
            defaultQuat.eulerAngles = _defaultRotation;
            transform.rotation = defaultQuat;
        }
    }    
}