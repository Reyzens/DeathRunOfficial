using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [Tooltip("Initial spawn position of the character")]
    public CheckpointManager m_checkPointManager;
    public Vector3 initialSpawn;
    public bool m_firstCheckpoint = false;

    private void Start()
    {
        m_checkPointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
        initialSpawn = GameObject.Find("DefaultSpawn").transform.position;
        m_checkPointManager.m_lastCheckpoint = initialSpawn;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(m_firstCheckpoint == false)
            {
                other.gameObject.transform.position = initialSpawn;
                m_firstCheckpoint = true;
            }
            else
            {
                other.gameObject.transform.position = m_checkPointManager.m_lastCheckpoint;
            }
           
        }
    }
}