using UnityEngine;
using TMPro;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rescueCountText;
    [SerializeField] private TextMeshProUGUI _dieCountText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void Awake()
    {
        GameManager.Instance.OnRescueCountChanged += UpdateRescueCount;
        GameManager.Instance.OnDieCountChanged += UpdateDieCount;
        GameManager.Instance.OnHealthChanged += UpdateHealth;
        GameManager.Instance.OnTimerUpdate += UpdateTimer;

        UpdateRescueCount(GameManager.Instance.RescueCount);
        UpdateDieCount(GameManager.Instance.DieCount);
        UpdateHealth(GameManager.Instance.Health);
        UpdateTimer(GameManager.Instance.TimeRemaining);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnRescueCountChanged -= UpdateRescueCount;
        GameManager.Instance.OnDieCountChanged -= UpdateDieCount;
        GameManager.Instance.OnHealthChanged -= UpdateHealth;
        GameManager.Instance.OnTimerUpdate -= UpdateTimer;
    }

    private void UpdateRescueCount(int count)
    {
        if (_rescueCountText != null)
        {
            _rescueCountText.text = $"Rescued: {count}";
        }
    }

    private void UpdateDieCount(int count)
    {
        if (_dieCountText != null)
        {
            _dieCountText.text = $"Died: {count}";
        }
    }

    private void UpdateHealth(int health)
    {
        if (_healthText != null)
        {
            _healthText.text = $"Health: {health}";
        }
    }

    private void UpdateTimer(float timeRemaining)
    {
        if (_timerText != null)
        {
            int seconds = Mathf.CeilToInt(timeRemaining);
            _timerText.text = $"Time: {seconds}s";
        }
    }
}
