using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    private const int MAX_DIE_COUNT = 3;
    private int _rescueCount = 0;
    private int _dieCount = 0;
    private bool _gameOver = false;

    public event Action<int> OnRescueCountChanged;
    public event Action<int> OnDieCountChanged;
    public event Action OnGameLose;
    public event Action OnGameWin;

    public int RescueCount => _rescueCount;
    public int DieCount => _dieCount;
    public bool IsGameOver => _gameOver;

    public void IncrementRescueCount()
    {
        if (_gameOver) return;

        _rescueCount++;
        OnRescueCountChanged?.Invoke(_rescueCount);
    }

    public void IncrementDieCount()
    {
        if (_gameOver) return;

        _dieCount++;
        OnDieCountChanged?.Invoke(_dieCount);

        if (_dieCount >= MAX_DIE_COUNT)
        {
            GameLose();
        }
    }

    public void GameWin()
    {
        if (_gameOver) return;

        _gameOver = true;
        OnGameWin?.Invoke();
    }

    public void GameLose()
    {
        if (_gameOver) return;

        _gameOver = true;
        OnGameLose?.Invoke();
    }

    public void ResetCounts()
    {
        _rescueCount = 0;
        _dieCount = 0;
        _gameOver = false;
        OnRescueCountChanged?.Invoke(_rescueCount);
        OnDieCountChanged?.Invoke(_dieCount);
    }
}
