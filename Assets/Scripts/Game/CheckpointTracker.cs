using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : NetworkBehaviour
{
    [Tooltip("List of all checkpoints in the game")]
    public List<GameObject> checkpoints;

    private HashSet<GameObject> visitedCheckpoints;

    private void Start()
    {
        visitedCheckpoints = new HashSet<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer) return;

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            if (visitedCheckpoints.Contains(other.gameObject))
            {
                return;
            }

            visitedCheckpoints.Add(other.gameObject);

            if (visitedCheckpoints.Count == checkpoints.Count)
            {
                Debug.Log("All checkpoints visited!");
            }
        }
    }
}