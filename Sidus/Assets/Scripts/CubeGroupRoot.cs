using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeGroupRoot : MonoBehaviour
{
    [SerializeField]
    private int _group;

    [SerializeField]
    private Transform _movingCube;    

    public int Group => _group;

    private void OnMouseDown()
    {
        StartCoroutine(MoveByRoot());
    }

    public IEnumerator MoveByRoot()
    {
        CubeGroupRoot thisCubeNeighbor = GetNeighbor();

        CubeMover neighborMover = thisCubeNeighbor.GetComponent<CubeMover>();
        CubeRotator neighborRotator = thisCubeNeighbor.GetComponent<CubeRotator>();

        float timeToWait = Mathf.Max(neighborMover.MovingTime, neighborRotator.RotatingTime);

        neighborMover.StartMove();
        neighborRotator.StartRotate();

        yield return new WaitForSeconds(timeToWait);

        this.GetComponent<CubeMover>().StartMove();
        this.GetComponent<CubeRotator>().StartRotate();
    }

    private CubeGroupRoot GetNeighbor()
    {
        CubeGroupRoot[] allCubes = FindObjectsOfType<CubeGroupRoot>();

        List<CubeGroupRoot> group = new List<CubeGroupRoot>();
        foreach (CubeGroupRoot cube in allCubes)
        {
            if (cube.Group == this.Group && cube != this)
            {
                group.Add(cube);
            }
        }

        int minIndex = 0;
        float minDistance = float.PositiveInfinity;

        for (int i = 0; i < group.Count; i++)
        {
            float distance = Vector3.Distance(this.transform.position, group[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                minIndex = i;
            }
        }
                
        return group[minIndex];
    }
}
