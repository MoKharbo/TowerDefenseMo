using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] TextMeshProUGUI xpText;
    [SerializeField] Image xpBar;

    [Space(10)]
    [Header("Settings")]
    [SerializeField] int targetXP = 100;
    [SerializeField] int targetXPIncrease = 50;

    public int currentLevel;
    int currentXP;

    private void Start()
    {
        currentLevel = 1;
        UpdateHUD();
    }

    public void IncreaseXP(int amount)
    {
        currentXP += amount;
        CheckForLevelUp();
        UpdateHUD();
    }

    private void CheckForLevelUp()
    {
        while(currentXP >= targetXP)
        {
            currentXP -= targetXP;
            currentLevel++;
            targetXP += targetXPIncrease;
        }
    }

    private void UpdateHUD()
    {
        currentLevelText.text = "Level " + currentLevel;
        xpText.text = currentXP + "/" + targetXP;
        xpBar.fillAmount = (float)currentXP / (float)targetXP;
    }
}
