using UnityEngine;

public class FlamethrowerActivation : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_flameSystem;
    [SerializeField]
    private float m_flameMaxDuration;
    private float m_currentFlameDuration;
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
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("W pressed");
                m_flameSystem.gameObject.SetActive(true);
                m_currentFlameDuration = m_flameMaxDuration;
            }
        }
        else
        {
            m_currentFlameDuration -= Time.deltaTime;
        }
    }
}