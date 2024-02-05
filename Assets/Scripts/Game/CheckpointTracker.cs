using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour
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
        if (checkpoints.Contains(other.gameObject))
        {
            visitedCheckpoints.Add(other.gameObject);
            if (visitedCheckpoints.Count == checkpoints.Count)
            {
                Debug.Log("All checkpoints visited!");
                WinGame();
            }
        }
    }

    private void WinGame()
    {
        Debug.Log("You've won the game!");
        // Add your game winning logic here
    }
}