using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField]
    private Transform _rotatingCube;

    [SerializeField]
    private float _rotatingTime;

    private Vector3 _rotatingCubeStartPosition;

    public void StartRotate()
    {        
        StartCoroutine(RotateCubeCoroutine());
    }

    private IEnumerator RotateCubeCoroutine()
    {
        _rotatingCubeStartPosition = _rotatingCube.rotation.eulerAngles;

        float elapsedTime = 0;

        while (elapsedTime < _rotatingTime)
        {
            Quaternion newRot = new Quaternion();
            newRot.eulerAngles = LerpRotation(elapsedTime, _rotatingCubeStartPosition, transform.rotation.eulerAngles);
            _rotatingCube.rotation = newRot;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (_rotatingCube.rotation.eulerAngles != transform.rotation.eulerAngles)
        {
            Quaternion newRot = new Quaternion();
            newRot.eulerAngles = new Vector3(_rotatingCube.rotation.eulerAngles.x + (transform.rotation.eulerAngles.x - _rotatingCube.rotation.eulerAngles.x),
                _rotatingCube.rotation.eulerAngles.y + (transform.rotation.eulerAngles.y - _rotatingCube.rotation.eulerAngles.y),
                _rotatingCube.rotation.eulerAngles.z + (transform.rotation.eulerAngles.z - _rotatingCube.rotation.eulerAngles.z));
            _rotatingCube.rotation = newRot;
        }
    }

    private Vector3 LerpRotation(float time, Vector3 start, Vector3 target)
    {
        return (1.0f - time) * start + target * time;
    }
    
}
