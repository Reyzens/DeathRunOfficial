using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : NetworkBehaviour
{
    [SerializeField]
    private float m_FTCooldown;
    [SerializeField]
    private float m_doorCooldown;
    [SerializeField]
    private float m_platformAccelerationCooldown;
    [SerializeField]
    private float m_platformReverseCooldown;

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

    //Flamethrower set cooldowns
    [SyncVar]
    private float m_FTSet1CD = -1f;
    [SyncVar]
    private float m_FTSet2CD = -1f;
    [SyncVar]
    private float m_FTSet3CD = -1f;
    [SyncVar]
    private float m_FTSet4CD = -1f;
    [SyncVar]
    private float m_FTSet5CD = -1f;

    //Plateform cooldowns
    [SyncVar]
    private float m_plateformAccelerationCD = -1f;
    [SyncVar]
    private float m_plateformReverseCD = -1f;

    private void Update()
    {
        //Flamethrower cooldown update
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
            if (m_FTSet3CD > 0)
            {
                m_FTSet3CD -= Time.deltaTime;
            }
            if (m_FTSet4CD > 0)
            {
                m_FTSet4CD -= Time.deltaTime;
            }
            if (m_FTSet5CD > 0)
            {
                m_FTSet5CD -= Time.deltaTime;
            }

            //Platform cd logic
            if (m_plateformAccelerationCD > 0)
            {
                m_plateformAccelerationCD -= Time.deltaTime;
            }
            if (m_plateformReverseCD > 0)
            {
                m_plateformReverseCD -= Time.deltaTime;
            }

        }
    }

    public void OnFTSet1()
    {
        //Debug.Log("Button clicked");
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
        if (isClient && m_FTSet3CD < 0)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieThree)
            {
                flamethrower.CommandActivatedEffect();
            }
            m_FTSet3CD = m_FTCooldown;
        }
    }

    public void OnFTSet4()
    {
        if (isClient && m_FTSet4CD < 0)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieFour)
            {
                flamethrower.CommandActivatedEffect();
            }
            m_FTSet4CD = m_FTCooldown;
        }
    }

    public void OnFTSet5()
    {
        if (isClient && m_FTSet5CD < 0)
        {
            foreach (FlamethrowerActivation flamethrower in m_flamethrowerSerieFive)
            {
                flamethrower.CommandActivatedEffect();
            }
            m_FTSet5CD = m_FTCooldown;
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
        if (isClient && m_plateformReverseCD < 0)
        {
            foreach (MovingPlatform movingPlatform in m_movingPlatformSerieOne)
            {
                movingPlatform.CommandReverseActivation();
            }
            m_plateformReverseCD = m_platformReverseCooldown;
        }
    }

    public void AccelerateMovingPlatform()
    {
        if (isClient && m_plateformAccelerationCD < 0)
        {
            foreach (MovingPlatform movingPlatform in m_movingPlatformSerieOne)
            {
                movingPlatform.CommandAccelerateActivation();
            }
            m_plateformAccelerationCD = m_platformAccelerationCooldown;
        }
    }
}
