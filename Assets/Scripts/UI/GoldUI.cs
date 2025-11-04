using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GoldUI : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public float goldAmount = 50f;

    private void OnEnable()
    {
        Enemy1.GoldDropped += UpdateGold;
    }

    private void OnDisable()
    {
        Enemy1.GoldDropped -= UpdateGold;
    }

    private void UpdateGold(float amount)
    {
        
        goldAmount += amount;
        goldText.text = "Gold: " + goldAmount;
    }
}
