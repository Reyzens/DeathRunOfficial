using TMPro;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    [SerializeField]
    private string m_userName;

    private void Start()
    {
    }

    public void SetUsername(string userName)
    {
        m_userName = userName;
        GetComponent<TextMeshProUGUI>().text = m_userName;
    }

    public bool CompareUserame(string usernameToCompare)
    {
        if (m_userName == usernameToCompare) return true;
        return false;
    }

    public string GetUsername()
    { return m_userName; }

}
