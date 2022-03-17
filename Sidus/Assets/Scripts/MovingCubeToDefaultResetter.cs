using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeToDefaultResetter : MonoBehaviour
{
    private Vector3 _defaultPosition;

    private void Start()
    {
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _defaultPosition;
        }
    }    
}
