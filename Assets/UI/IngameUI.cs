using UnityEngine;
using TMPro;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rescueCountText;
    [SerializeField] private TextMeshProUGUI _dieCountText;

    private void Awake()
    {
        GameManager.Instance.OnRescueCountChanged += UpdateRescueCount;
        GameManager.Instance.OnDieCountChanged += UpdateDieCount;

        UpdateRescueCount(GameManager.Instance.RescueCount);
        UpdateDieCount(GameManager.Instance.DieCount);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnRescueCountChanged -= UpdateRescueCount;
        GameManager.Instance.OnDieCountChanged -= UpdateDieCount;
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
}
