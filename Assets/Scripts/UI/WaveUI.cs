using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    private WaveSpawner waveSpawner;
    public int currentWave;

    private void OnEnable()
    {
        WaveSpawner.currentWaveCount += UpdateWaveCount;
    }

    private void OnDisable()
    {
        WaveSpawner.currentWaveCount -= UpdateWaveCount;
    }

    public void UpdateWaveCount(int wave)
    {
        waveText.text = "Wave: " + wave;
        currentWave = wave;
    }
}
