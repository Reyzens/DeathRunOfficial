using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySelection : MonoBehaviour
{
    [SerializeField]
    public CanvasUI m_playerList;

    // Start is called before the first frame update
    void Start()
    {
        m_playerList = GetComponent<CanvasUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {

    }
}
