using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoving : MonoBehaviour
{
    [SerializeField]
    private Transform _movingCube;

    [SerializeField, Min(1f)]
    private float _arcRadius;

    [SerializeField]
    private float _movingTime;

    private Vector3 _movingCubeStartPosition;

    private Vector3 _bezierThirdPoint;

    public void OnMouseDown()
    {
        StartCoroutine(MoveCubeCoroutine());
    }

    private IEnumerator MoveCubeCoroutine()
    {
        _movingCubeStartPosition = _movingCube.position;
        
        SetBezierPoint();

        float elapsedTime = 0;

        while (elapsedTime < _movingTime)
        {
            MovingCube(elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }        

    private void MovingCube(float time)
    {
        _movingCube.position = Bezier.GetPoint(_movingCubeStartPosition, _bezierThirdPoint, transform.position, Mathf.Clamp01(time));
    }   

    private void SetBezierPoint()
    {
        Vector3 center = new Vector3(
            (_movingCube.position.x + transform.position.x) / 2,
            (_movingCube.position.y + transform.position.y) / 2,
            (_movingCube.position.z + transform.position.z) / 2
            );

        _bezierThirdPoint = new Vector3(center.x, center.y + _arcRadius, center.z);
    }    
}
