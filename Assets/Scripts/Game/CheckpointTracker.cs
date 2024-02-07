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
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You've won the game!");
        }
    }

    private void WinGame()
    {
        Debug.Log("You've won the game!");
        // Add your game winning logic here
    }
}