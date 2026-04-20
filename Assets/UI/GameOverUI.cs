using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    private void Awake()
    {
        GameManager.Instance.OnGameLose += HandleGameLose;
        GameManager.Instance.OnGameWin += HandleGameWin;

        _losePanel?.SetActive(false);
        _winPanel?.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameLose -= HandleGameLose;
        GameManager.Instance.OnGameWin -= HandleGameWin;
    }

    private void HandleGameLose()
    {
        if (_losePanel != null)
        {
            _losePanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    private void HandleGameWin()
    {
        if (_winPanel != null)
        {
            _winPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
