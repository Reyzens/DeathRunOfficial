using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : NetworkBehaviour
{
    [SerializeField]
    public List<Transform> movingCoordinate;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float accelerationDuration;
    [SerializeField]
    private float speedMultiplier;

    private int coordinateIndex;
    private int lastCoordinateIndex;
    private bool isInReverse;
    private float currentAccelerationTime = 0;

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

        if (Vector3.Distance(transform.position, movingCoordinate[coordinateIndex].position) < TRANSFORM_MARGIN)
        {
            //Debug.Log("Reached destination");
            ChangeCoordinate();
            //Debug.Log(coordinateIndex);
        }
    }

    private void UpdatePosition()
    {
        currentAccelerationTime -= Time.deltaTime;
        if (currentAccelerationTime < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, movingCoordinate[coordinateIndex].position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movingCoordinate[coordinateIndex].position, speed * speedMultiplier * Time.deltaTime);
        }
    }

    [ClientRpc]
    private void Accelerate()
    {
        currentAccelerationTime = accelerationDuration;
    }

    [ClientRpc]
    private void Reverse()
    {
        isInReverse = !isInReverse;
        ChangeCoordinate();
    }

    [Command(requiresAuthority = false)]
    public void CommandReverseActivation()
    {
        Reverse();
    }

    [Command(requiresAuthority = false)]
    public void CommandAccelerateActivation()
    {
        Accelerate();
    }

    private void ChangeCoordinate()
    {
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
    }
}
