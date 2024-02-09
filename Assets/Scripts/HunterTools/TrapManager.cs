using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : NetworkBehaviour
{
    [SerializeField]
    private List<FlamethrowerActivation> m_flamethrowerSerieOne = new List<FlamethrowerActivation>();
    [SerializeField]
    private List<FlamethrowerActivation> m_flamethrowerSerieTwo = new List<FlamethrowerActivation>();
    [SerializeField]
    private List<FlamethrowerActivation> m_flamethrowerSeriethree = new List<FlamethrowerActivation>();
    [SerializeField]
    private List<TrapDoorController> m_trapDoorSerieOne = new List<TrapDoorController>();
    [SerializeField]
    private List<TrapDoorController> m_TrapDoorSerieTwo = new List<TrapDoorController>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I)) { OnFTSet1(); }
    }

    public void OnFTSet1()
    {
        Debug.Log("Button clicked");
        if (isClient)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieOne)
            {
                flamethrower.CommandActivatedEffect();
            }
        }
    }

    public void OnFTSet2()
    {
        if (isClient)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieTwo)
            {
                flamethrower.CommandActivatedEffect();
            }
        }
    }
}
