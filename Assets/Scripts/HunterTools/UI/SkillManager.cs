using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private List<SSkillCallData> m_SkillCallList = new List<SSkillCallData>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (SSkillCallData skillCall in m_SkillCallList)
        {

        }
    }

    public void AddSkillCall(string skillName, uint networkID, GameObject trap)
    {
        m_SkillCallList.Add(new SSkillCallData(skillName, networkID, trap));
    }
}

struct SSkillCallData
{
    private string m_name;
    private uint m_networkID;
    private GameObject m_trap;

    public SSkillCallData(string name, uint networkID, GameObject trap)
    {
        m_name = name;
        m_networkID = networkID;
        m_trap = trap;
    }
}
