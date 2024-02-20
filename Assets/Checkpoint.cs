using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager m_checkpointManager;
    void Start()
    {
        m_checkpointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_checkpointManager.m_lastCheckpoint = transform.position;
        }
    }
}
