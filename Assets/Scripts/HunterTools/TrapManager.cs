using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : NetworkBehaviour
{
    [SerializeField]
    private float m_FTCooldown = 7.0f;
    [SerializeField]
    private float m_doorCooldown;
    [SerializeField]
    private float m_platformCooldown;

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
    private TrapDoorController m_trapDoorTwo;
    [SerializeField]
    private TrapDoorController m_trapDoorThree;
    [SerializeField]
    private TrapDoorController m_trapDoorFour;
    [SerializeField]
    private TrapDoorController m_trapDoorFive;
    [SerializeField]
    private TrapDoorController m_trapDoorSix;
    [SerializeField]
    private TrapDoorController m_trapDoorSeven;
    [SerializeField]
    private TrapDoorController m_trapDoorEigth;
    [SerializeField]
    private List<MovingPlatform> m_movingPlatformSerieOne = new List<MovingPlatform>();

    [SyncVar]
    private float m_FTSet1CD = -1f;
    [SyncVar]
    private float m_FTSet2CD = -1f;

    private void Update()
    {
        if (isServer)
        {
            if (m_FTSet1CD > 0)
            {
                m_FTSet1CD -= Time.deltaTime;
            }
            if (m_FTSet2CD > 0)
            {
                m_FTSet2CD -= Time.deltaTime;
            }
        }
    }

    public void OnFTSet1()
    {
        Debug.Log("Button clicked");
        if (isClient && m_FTSet1CD < 0)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieOne)
            {
                flamethrower.CommandActivatedEffect();
            }
            m_FTSet1CD = m_FTCooldown;
        }
    }

    public void OnFTSet2()
    {
        if (isClient && m_FTSet2CD < 0)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieTwo)
            {
                flamethrower.CommandActivatedEffect();
            }
            m_FTSet2CD = m_FTCooldown;
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
        if (isClient)
        {
            m_trapDoorOne.CommandActivatedEffect();
        }
    }

    public void OnDoor2()
    {
        if (isClient)
        {
            m_trapDoorTwo.CommandActivatedEffect();
        }
    }

    public void OnDoor3()
    {
        if (isClient)
        {
            m_trapDoorThree.CommandActivatedEffect();
        }
    }

    public void OnDoor4()
    {
        if (isClient)
        {
            m_trapDoorFour.CommandActivatedEffect();
        }
    }

    public void OnDoor5()
    {
        if (isClient)
        {
            m_trapDoorFive.CommandActivatedEffect();
        }
    }

    public void OnDoor6()
    {
        if (isClient)
        {
            m_trapDoorSix.CommandActivatedEffect();
        }
    }

    public void OnDoor7()
    {
        if (isClient)
        {
            m_trapDoorSeven.CommandActivatedEffect();
        }
    }

    public void OnDoor8()
    {
        if (isClient)
        {
            m_trapDoorEigth.CommandActivatedEffect();
        }
    }

    public void InverseMovingPlatform()
    {
        if (isClient)
        {
            foreach (MovingPlatform movingPlatform in m_movingPlatformSerieOne)
            {
                movingPlatform.CommandReverseActivation();
            }
        }
    }

    public void AccelerateMovingPlatform()
    {
        if (isClient)
        {
            foreach (MovingPlatform movingPlatform in m_movingPlatformSerieOne)
            {
                movingPlatform.CommandAccelerateActivation();
            }
        }
    }
}
