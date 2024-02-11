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
    private List<FlamethrowerActivation> m_flamethrowerSerieThree = new List<FlamethrowerActivation>();
    [SerializeField]
    private List<FlamethrowerActivation> m_flamethrowerSerieFour = new List<FlamethrowerActivation>();
    [SerializeField]
    private List<FlamethrowerActivation> m_flamethrowerSerieFive = new List<FlamethrowerActivation>();
    [SerializeField]
    private TrapDoorController m_trapDoorOne;
    [SerializeField]
    private List<TrapDoorController> m_TrapDoorSerieTwo = new List<TrapDoorController>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

    public void OnFTSet3()
    {
        if (isClient)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieThree)
            {
                flamethrower.CommandActivatedEffect();
            }
        }
    }

    public void OnFTSet4()
    {
        if (isClient)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieFour)
            {
                flamethrower.CommandActivatedEffect();
            }
        }
    }

    public void OnFTSet5()
    {
        if (isClient)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieFive)
            {
                flamethrower.CommandActivatedEffect();
            }
        }
    }

    public void OnDoor1()
    {
        m_trapDoorOne.CommandActivatedEffect();
    }
}
