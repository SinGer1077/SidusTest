using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRandomRotator : MonoBehaviour
{   private void Start()
    {
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(GetRandomAngle(), GetRandomAngle(), GetRandomAngle());

        transform.rotation = newRotation;
    }

    private float GetRandomAngle()
    {
        return Random.Range(-180, 180);
    }
}
