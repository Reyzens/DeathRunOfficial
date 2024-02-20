using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : NetworkBehaviour
{

    [SerializeField]
    private TrapList m_sceneTrapList;


    private List<FlamethrowerActivation> m_flamethrowerSerieOne = new List<FlamethrowerActivation>();
    private List<FlamethrowerActivation> m_flamethrowerSerieTwo = new List<FlamethrowerActivation>();
    private List<FlamethrowerActivation> m_flamethrowerSerieThree = new List<FlamethrowerActivation>();
    private List<FlamethrowerActivation> m_flamethrowerSerieFour = new List<FlamethrowerActivation>();
    private List<FlamethrowerActivation> m_flamethrowerSerieFive = new List<FlamethrowerActivation>();
    private TrapDoorController m_trapDoorOne;
    private TrapDoorController m_trapDoorTwo;
    private TrapDoorController m_trapDoorThree;
    private TrapDoorController m_trapDoorFour;
    private TrapDoorController m_trapDoorFive;
    private TrapDoorController m_trapDoorSix;
    private TrapDoorController m_trapDoorSeven;
    private TrapDoorController m_trapDoorEigth;
    private List<MovingPlatform> m_movingPlatformSerieOne = new List<MovingPlatform>();



    private void Start()
    {
        m_sceneTrapList = GameObject.FindObjectOfType<TrapList>();
    }

    private void Update()
    {
        m_sceneTrapList = GameObject.FindObjectOfType<TrapList>();
    }

    public void OnFTSet1()
    {
        m_sceneTrapList.OnFTSet1();
    }

    public void OnFTSet2()
    {
        m_sceneTrapList.OnFTSet2();
    }

    public void OnFTSet3()
    {
        m_sceneTrapList.OnFTSet3();
    }

    public void OnFTSet4()
    {
        m_sceneTrapList.OnFTSet4();
    }

    public void OnFTSet5()
    {
        m_sceneTrapList.OnFTSet5();
    }

    public void OnDoor1()
    {
        m_sceneTrapList.OnDoor1();
    }

    public void OnDoor2()
    {
        m_sceneTrapList.OnDoor2();
    }

    public void OnDoor3()
    {
        m_sceneTrapList.OnDoor3();
    }

    public void OnDoor4()
    {
        m_sceneTrapList.OnDoor4();
    }

    public void OnDoor5()
    {
        m_sceneTrapList.OnDoor5();
    }

    public void OnDoor6()
    {
        m_sceneTrapList.OnDoor6();
    }

    public void OnDoor7()
    {
        m_sceneTrapList.OnDoor7();
    }

    public void OnDoor8()
    {
        m_sceneTrapList.OnDoor8();
    }

    public void InverseMovingPlatform()
    {
        m_sceneTrapList.InverseMovingPlatform();
    }

    public void AccelerateMovingPlatform()
    {
        m_sceneTrapList.AccelerateMovingPlatform();
    }

}
