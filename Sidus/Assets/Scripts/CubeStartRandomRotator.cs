using UnityEngine;

public class CubeStartRandomRotator : MonoBehaviour
{   private void Start()
    {
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(GetRandomAngle(), GetRandomAngle(), GetRandomAngle());

        transform.rotation = newRotation;
    }

    private float GetRandomAngle()
    {
        return Random.Range(0, 360);
    }
}
