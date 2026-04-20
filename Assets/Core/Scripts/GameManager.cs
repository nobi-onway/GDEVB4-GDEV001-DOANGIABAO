using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    private const int MAX_DIE_COUNT = 3;
    private const float GAME_DURATION = 60f;
    private const int MAX_HEALTH = 10;
    private int _rescueCount = 0;
    private int _dieCount = 0;
    private int _health = MAX_HEALTH;
    private bool _gameOver = false;
    private CountdownTimer _gameTimer;
    private float _timeRemaining;
    private float _elapsedTime = 0f;

    public event Action<int> OnRescueCountChanged;
    public event Action<int> OnDieCountChanged;
    public event Action<int> OnHealthChanged;
    public event Action<float> OnTimerUpdate;
    public event Action OnGameLose;
    public event Action OnGameWin;

    public int RescueCount => _rescueCount;
    public int DieCount => _dieCount;
    public int Health => _health;
    public bool IsGameOver => _gameOver;
    public float TimeRemaining => _timeRemaining;

    public GameManager()
    {
        InitializeGameTimer();
    }

    private void InitializeGameTimer()
    {
        _gameTimer = new CountdownTimer(GAME_DURATION);
        _timeRemaining = GAME_DURATION;
    }

    public void UpdateGameTimer()
    {
        if (_gameOver || _gameTimer == null) return;

        _gameTimer.Tick(Time.deltaTime, OnGameTimerFinish);
        _elapsedTime += Time.deltaTime;
        _timeRemaining = Mathf.Max(0, GAME_DURATION - _elapsedTime);
        OnTimerUpdate?.Invoke(_timeRemaining);
    }

    private void OnGameTimerFinish()
    {
        GameWin();
    }

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

    public void DamageHealth(int amount = 1)
    {
        if (_gameOver) return;

        _health -= amount;
        OnHealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            GameLose();
        }
    }

    public void HealHealth(int amount = 1)
    {
        if (_gameOver) return;

        _health = Mathf.Min(_health + amount, MAX_HEALTH);
        OnHealthChanged?.Invoke(_health);
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
        _health = MAX_HEALTH;
        _gameOver = false;
        OnRescueCountChanged?.Invoke(_rescueCount);
        OnDieCountChanged?.Invoke(_dieCount);
        OnHealthChanged?.Invoke(_health);
    }
}
