using UnityEngine;
using UnityEngine.UI;

public class EnergyUIManager : MonoBehaviour
{
    public Image m_energyImage;

    public void UpdateStamina(float staminaValue)
    {
        if (m_energyImage != null)
        {
            Debug.Log("In Update Stamina");
            m_energyImage.fillAmount = staminaValue / 3f;
        }
    }
}