using AYellowpaper.SerializedCollections;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillButton : MonoBehaviour
{
    [SerializeField]
    private SkillManager skillManager;

    [SerializedDictionary("Skill name", "Button")]
    private SerializedDictionary<string, SSkillButtonData> m_skillDictionary = new SerializedDictionary<string, SSkillButtonData>();

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        foreach (var skill in m_skillDictionary.Keys.ToList())
        {
            m_skillDictionary[skill].SetButton(root.Q<Button>(skill));
        }

        foreach (var skillButton in m_skillDictionary.Keys.ToList())
        {
            m_skillDictionary[skillButton].GetButton().clicked += delegate { OnClick(skillButton, m_skillDictionary[skillButton].GetTrap()); };
        }
    }

    private void OnClick(string skillName, GameObject trapActivated)
    {
        //skillManager.AddSkillCall(skillName);
    }
}

struct SSkillButtonData
{
    private Button button;
    private GameObject trap;

    public void SetButton(Button rootButton) { button = rootButton; }
    public Button GetButton() { return button; }
    public GameObject GetTrap() { return trap; }
}