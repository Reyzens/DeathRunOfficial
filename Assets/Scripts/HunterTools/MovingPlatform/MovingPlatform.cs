using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    public List<Transform> movingCoordinate;
    [SerializeField]
    private float speed;

    private int coordinateIndex;
    private int lastCoordinateIndex;
    private bool isInReverse;

    const float TRANSFORM_MARGIN = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        //Start at first coordinate since index 0 is initial position
        coordinateIndex = 1;
        isInReverse = false;
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
                    //Go back to first index coordinate
                    //Debug.Log("Return to origine");
                    coordinateIndex = 0;
                }
                return;
            }

            if (isInReverse)
            {
                //Check if at first index coordinate
                if (coordinateIndex != 0)
                {
                    //Debug.Log("Go down one coordinate");
                    coordinateIndex--;
                }
                else
                {
                    //Go back to last index coordinate
                    //Debug.Log("Reset coordinate order");
                    coordinateIndex = lastCoordinateIndex;
                }
            }
            Debug.Log(coordinateIndex);
        }
    }

    private void UpdatePosition()
    {
        //transform.position = Vector3.MoveTowards(transform.position, nextCoordinate, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, movingCoordinate[coordinateIndex].position, speed * Time.deltaTime);
    }
}
