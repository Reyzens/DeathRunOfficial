using Mirror;
using UnityEngine;

public class FlamethrowerActivation : NetworkBehaviour
{
    [SerializeField]
    private ParticleSystem m_flameSystem;
    [SerializeField]
    private double m_flameMaxDuration;

    private double m_currentFlameDuration = -1;
    // Start is called before the first frame update
    void Start()
    {
        m_flameSystem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_currentFlameDuration < 0)
        {
            if (m_flameSystem.gameObject.activeInHierarchy == true)
            {
                m_flameSystem.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                if (isClient)
                {
                    CommandActivatedEffect();
                }
            }
        }
        else
        {
            //Debug.Log(m_currentFlameDuration);
            m_currentFlameDuration -= Time.deltaTime;
        }
    }

    [Command(requiresAuthority = false)]
    public void CommandActivatedEffect()
    {
        ActivateClientFlamethrower(NetworkTime.time);
        //ActivateClientFlamethrower(Time.timeAsDouble);
    }

    [ClientRpc]
    private void ActivateClientFlamethrower(double timeStamp)
    {
        m_flameSystem.gameObject.SetActive(true);
        m_currentFlameDuration = m_flameMaxDuration - (timeStamp - NetworkTime.time);
        //m_currentFlameDuration = m_flameMaxDuration;
        Debug.Log(m_currentFlameDuration);
    }
}