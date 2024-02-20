using UnityEngine;
using UnityEngine.UI;

public class EnergyUIManager : MonoBehaviour
{
    public Image energyImage;

    public void UpdateStamina(float staminaValue)
    {
        if (energyImage != null)
        {
            Debug.Log("In Update Stamina");
            energyImage.fillAmount = staminaValue / 3f;
        }
    }
}