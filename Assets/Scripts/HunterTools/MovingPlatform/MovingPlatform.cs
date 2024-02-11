using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    public List<Transform> movingCoordinate;
    [SerializeField]
    private float speed;

    private Transform initialPosition;
    private int coordinateIndex;
    private int lastCoordinateIndex;
    private bool isInReverse;

    const float TRANSFORM_MARGIN = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        coordinateIndex = 1;
        isInReverse = false;
        movingCoordinate.Insert(0, initialPosition);
        lastCoordinateIndex = movingCoordinate.Count - 1;
        //Debug.Log(movingCoordinate[0].position);
    }

    void Update()
    {
        //Debug.Log("Update platform");
        UpdatePosition();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Platform position " + transform.position);
            Debug.Log("Platform locaposition " + transform.localPosition);
            Debug.Log("Moving position " + movingCoordinate[coordinateIndex].position);
            Debug.Log("moving localposition " + movingCoordinate[coordinateIndex].localPosition);
        }

        if (Vector3.Distance(transform.position, movingCoordinate[coordinateIndex].position) < TRANSFORM_MARGIN)
        {
            Debug.Log("Reached destination");
            if (!isInReverse)
            {
                if (coordinateIndex != lastCoordinateIndex)
                {
                    //Debug.Log("Go up one coordinate");
                    coordinateIndex++;
                }
                else
                {
                    //Debug.Log("Return to origine");
                    isInReverse = true;
                    coordinateIndex--;
                }
                return;
            }

            if (isInReverse)
            {
                if (coordinateIndex > 0)
                {
                    //Debug.Log("Go down one coordinate");
                    coordinateIndex--;
                }
                else
                {
                    //Debug.Log("Reset coordinate order");
                    isInReverse = false;
                    coordinateIndex = 1;
                }
            }
            Debug.Log(coordinateIndex);
        }

        //if (transform.position == nextCoordinate)
        //{
        //    if (!isInReverse)
        //    {
        //        if (coordinateIndex != lastCoordinateIndex)
        //        {
        //            coordinateIndex++;
        //            nextCoordinate = movingCoordinate[coordinateIndex].position;
        //        }
        //        else
        //        {
        //            isInReverse = true;
        //            coordinateIndex--;
        //            nextCoordinate = movingCoordinate[coordinateIndex].position;
        //        }
        //    }

        //    if (isInReverse)
        //    {
        //        if (nextCoordinate == movingCoordinate[0].position)
        //        {
        //            nextCoordinate = initialPosition.position;
        //        }
        //        else if (nextCoordinate != initialPosition.position)
        //        {
        //            coordinateIndex--;
        //            nextCoordinate = movingCoordinate[coordinateIndex].position;
        //        }
        //        else
        //        {
        //            isInReverse = false;
        //            coordinateIndex = 0;
        //            nextCoordinate = movingCoordinate[coordinateIndex].position;
        //        }
        //    }
        //}
    }

    private void UpdatePosition()
    {
        //transform.position = Vector3.MoveTowards(transform.position, nextCoordinate, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, movingCoordinate[coordinateIndex].position, speed * Time.deltaTime);
    }
}
