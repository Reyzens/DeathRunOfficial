using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Serialize]
    public List<Transform> movingCoordinate;
    [SerializeField]
    private float speed;


    private int coordinateIndex;
    private int lastCoordinateIndex;
    private Vector3 initialPosition;
    private bool isInReverse;
    private Vector3 nextCoordinate;

    // Start is called before the first frame update
    void Start()
    {
        coordinateIndex = 0;
        lastCoordinateIndex = movingCoordinate.Count - 1;
        isInReverse = false;
        initialPosition = transform.position;
        //Debug.Log(movingCoordinate[0].position);
        nextCoordinate = movingCoordinate[coordinateIndex].position;
    }

    void Update()
    {
        //Debug.Log("Update platform");
        UpdatePosition();

        if (transform.position == nextCoordinate)
        {
            if (!isInReverse)
            {
                if (coordinateIndex != lastCoordinateIndex)
                {
                    coordinateIndex++;
                    nextCoordinate = movingCoordinate[coordinateIndex].position;
                }
                else
                {
                    isInReverse = true;
                    coordinateIndex--;
                    nextCoordinate = movingCoordinate[coordinateIndex].position;
                }
            }

            if (isInReverse)
            {
                if (nextCoordinate == movingCoordinate[0].position)
                {
                    nextCoordinate = initialPosition;
                }
                else if (nextCoordinate != initialPosition)
                {
                    coordinateIndex--;
                    nextCoordinate = movingCoordinate[coordinateIndex].position;
                }
                else
                {
                    isInReverse = false;
                    coordinateIndex = 0;
                    nextCoordinate = movingCoordinate[coordinateIndex].position;
                }
            }
        }
    }

    private void UpdatePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextCoordinate, speed * Time.fixedDeltaTime);
    }
}
